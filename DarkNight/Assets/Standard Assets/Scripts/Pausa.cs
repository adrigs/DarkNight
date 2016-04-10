using UnityEngine;
using System.Collections;

public class Pausa : MonoBehaviour {

    public bool juegoPausado = false;
    private bool mostrarMenu = false;

	// Use this for initialization
	void Awake () {
        GameObject.Find("MenuPausa").GetComponent<Canvas>().enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
       
       if(Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("Inventario").GetComponent<Inventario>().mostrarMenu == false) pausar();
	}

    public void pausar()
    {
        juegoPausado = !juegoPausado;
        
        if (juegoPausado)
        {

            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Girar>().enabled = false;
            GameObject.FindGameObjectWithTag("Enemigo").GetComponent<AudioSource>().enabled = false;
            Cursor.visible = true;
            mostrarMenu = true;
        }
        else
        {
            Time.timeScale = 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Girar>().enabled = true;
            GameObject.FindGameObjectWithTag("Enemigo").GetComponent<AudioSource>().enabled = true;
            Cursor.visible = false;
            mostrarMenu = false;
        }

        if (mostrarMenu) GameObject.Find("MenuPausa").GetComponent<Canvas>().enabled = true;
         else GameObject.Find("MenuPausa").GetComponent<Canvas>().enabled = false;

    }
}
