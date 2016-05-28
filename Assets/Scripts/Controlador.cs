using UnityEngine;
using System.Collections;

public class Controlador : MonoBehaviour {

    [Header("Compuertas")]
    public bool compuertaEscojida = false;
    public string compuertaSeleccionada;

    public GameObject[] objetos;
    public GameObject objetoSeleccionado;

    [Space(5)]
    [Header("Camara")]
    public Camera cam;

	void Start () {
	    if (cam == null)
        {
            cam = Camera.main;
        }    
	}

    void Update() {
        //colocar una compuerta;

        if (Input.GetMouseButtonDown(2) && objetoSeleccionado != null)
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Floor")
                {
                    GameObject obj = Instantiate(objetoSeleccionado, hit.point + Vector3.up * 0.36f, Quaternion.identity) as GameObject;
                    if (compuertaEscojida)
                    {
                        obj.GetComponent<Compuerta>().tipo = compuertaSeleccionada;
                    }                    
                }
            }
        }

	}

    void EscojerInput()
    {
        objetoSeleccionado = objetos[1];
    }

    void EscojerOutput()
    {
        objetoSeleccionado = objetos[2];
        compuertaEscojida = false;
    }

    void EscojerAND ()
    {
        objetoSeleccionado = objetos[0];
        compuertaSeleccionada = "and";
        compuertaEscojida = false;
    }

    void EscojerOR()
    {
        objetoSeleccionado = objetos[0];
        compuertaSeleccionada = "or";
        compuertaEscojida = true;
    }

    void EscojerNAND()
    {
        objetoSeleccionado = objetos[0];
        compuertaSeleccionada = "nand";
        compuertaEscojida = true;
    }

    void EscojerNOR()
    {
        objetoSeleccionado = objetos[0];
        compuertaSeleccionada = "nor";
        compuertaEscojida = true;
    }
}
