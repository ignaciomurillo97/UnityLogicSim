using UnityEngine;
using System.Collections;

public class InputPort : MonoBehaviour {

    public int valorSalida = 0;
    int valorPrevio = 0;
    [Tooltip("Boton, Toggle")]
    public string tipoEntrada;

    public TextMesh texto;
    Renderer rend;
    [HideInInspector]
    public bool simulando = true;

	void Start () {
        rend = gameObject.GetComponent<Renderer>() as Renderer;
	}
	
	void Update () {
        if (valorSalida != valorPrevio)
        {
            UpdateColor();
        }
        valorPrevio = valorSalida;
    }

    void toggle()
    {
        if (tipoEntrada == "Boton")
        {
            StartCoroutine(boton());
        }
        else if (tipoEntrada == "Toggle")
        {
            if (valorSalida == 0) valorSalida = 1;
            else valorSalida = 0;
        }
    }

    IEnumerator boton()
    {
        valorSalida = 1;
        yield return new WaitForSeconds(1);
        valorSalida = 0;
    }

    void UpdateColor()
    {
        if (valorSalida == 1)
        {
            rend.material.color = new Color(0.5f, 0.5f, 1);
            texto.text = "1";
        }

        else
        {
            rend.material.color = new Color(1, 1, 1);
            texto.text = "0";
        }
    }

    void OnMouseOver()
    {
        rend.material.color = new Color(1,0.75f,0.5f);
        if (Input.GetMouseButtonDown(0) && simulando)
        {
            toggle();
        }
    }
    void OnMouseExit()
    {
        UpdateColor();
    }
}
