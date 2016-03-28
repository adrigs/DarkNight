using UnityEngine;
using System.Collections;

public class Pausa : MonoBehaviour {

    private bool juegoPausado = false;
    private bool mostrarMenu = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       if(Input.GetKeyDown(KeyCode.Escape)) pausar();
	}

    private void pausar()
    {
        juegoPausado = !juegoPausado;

        if (juegoPausado)
        {

            Time.timeScale = 0;
           // GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = false;
           // GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = false;
            mostrarMenu = true;
        }
        else
        {
            Time.timeScale = 1;
          //  GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = true;
          //  GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = true;
            mostrarMenu = false;
        }

        if (mostrarMenu) GameObject.Find("MenuPausa").GetComponent<GUITexture>().enabled = true;
        else GameObject.Find("MenuPausa").GetComponent<GUITexture>().enabled = false;

    }
}
