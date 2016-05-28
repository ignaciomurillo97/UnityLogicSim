using UnityEngine;
using System.Collections;

public class Controlador : MonoBehaviour {

    [Header("Compuertas")]
    public bool compuerta = false;
    public string[] compuertasDisponibles = {"and", "or", "nand", "nor", "xnor"};
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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Floor")
                {
                    GameObject obj = Instantiate(objetoSeleccionado, hit.point + Vector3.up * 0.36f, Quaternion.identity) as GameObject;
                }
            }
        }

	}
}
