using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Compuerta : MonoBehaviour {

    [Header("Tipo de compuerta")]
    [Tooltip("and, or, nand, nor")]
    public string tipo;

    [Space(5)]
    [Header("Entradas/Salidas")]
    public List<GameObject> entradas = new List<GameObject>();
    public GameObject salida;

    [Space(5)]
    [Header("Valor Salida")]
    public int valorSalida;

    [Space(5)]
    [Header("Connecciones")]
    public GameObject dataPath;
    public List<GameObject> dataPathObjs = new List<GameObject>();

    [Space(5)]
    [Header("Misc")]
    public TextMesh texto;
    Renderer rend;
    [HideInInspector]
    public bool simulando =  true;

	void Start () {
        rend = gameObject.GetComponent<Renderer>() as Renderer;
	}
	
	void Update () {
	    if (simulando)
        {       
           //Calcular el valor de salida                          
            List<int> valoresEntrada = new List<int>();
            foreach (GameObject entrada in entradas)
            {
                if (entrada != null)
                {
                    if (entrada.transform.tag == "Compuerta") valoresEntrada.Add(entrada.GetComponent<Compuerta>().valorSalida);
                    else if (entrada.transform.tag == "Input") valoresEntrada.Add(entrada.GetComponent<InputPort>().valorSalida);
                }
            }

            switch (tipo)
            {
                case "and":
                    valorSalida = 1;
                    foreach (int valor in valoresEntrada)
                    {                        
                        if (valor == 0)
                        {
                            valorSalida = 0;
                            break;                            
                        }
                    }                    
                    break;

                case "or":
                    valorSalida = 0;
                    foreach (int valor in valoresEntrada)
                    {
                        if (valor == 1)
                        {
                            valorSalida = 1;
                            break;
                        }
                    }                    
                    break;

                case "nand":
                    valorSalida = 0;
                    foreach (int valor in valoresEntrada)
                    {
                        if (valor == 0)
                        {
                            valorSalida = 1;
                            break;
                        }
                    }                    
                    break;

                case "nor":
                    valorSalida = 1;
                    foreach (int valor in valoresEntrada)
                    {
                        if (valor == 1)
                        {
                            valorSalida = 0;
                            break;
                        }
                    }                    
                    break;


                default:
                    break;

            }

            //Calcular Conecciones

            for (int i = 0; i < dataPathObjs.Count; i++)
            {
                if (entradas[i] != null)
                {
                    LineRenderer lr = dataPathObjs[i].transform.GetComponent<LineRenderer>() as LineRenderer;
                    Vector3 pos1 = entradas[i].transform.position;
                    Vector3 pos2 = dataPathObjs[i].transform.position;
                    conectar(pos1, pos2, lr);
                }
            }

            //Misc
            if (texto != null && texto.text != tipo)
            {
                texto.text = tipo;
            }
            
            if (valorSalida == 1)
            {
                rend.material.color = new Color(0.5f, 0.5f, 1);   
            }

            else
            {
                rend.material.color = new Color(1, 1, 1);
            }
        }        
	}

    void conectar(Vector3 punto1, Vector3 punto2, LineRenderer currLine)
    {
        currLine.SetPosition(0, punto1);
        currLine.SetPosition(1, punto2);
    }
}
