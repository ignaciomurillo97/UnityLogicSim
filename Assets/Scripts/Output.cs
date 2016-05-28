using UnityEngine;
using System.Collections;

public class Output : MonoBehaviour {

    public int valorEntrada;
    public GameObject entrada;
    public LineRenderer lr;
    public Renderer rend;

    void Start () {
        rend = GetComponent<Renderer>() as Renderer;
	}
	
	void Update () {
        if (entrada != null)
        {
            if (entrada.transform.tag == "Compuerta") valorEntrada = entrada.GetComponent<Compuerta>().valorSalida;
            else if (entrada.transform.tag == "Input") valorEntrada = entrada.GetComponent<InputPort>().valorSalida;

            lr.enabled = true;
            lr.SetPosition(0, transform.position - Vector3.up * 0.15f);
            lr.SetPosition(1, entrada.transform.position);
        }        
        else lr.enabled = false;

        if (valorEntrada == 1)
        {
            rend.material.color = new Color(0.5f, 0.5f, 1);
        }

        else
        {
            rend.material.color = new Color(1, 1, 1);
        }
    }
}
