﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class Inventario : MonoBehaviour {

   
    public bool mostrarMenu = false;
    Mochila mochila;
    public int posicion = 0;
    public int posicionSub = 0;
    public bool SubMenu = false;
    public bool SubObj = false;
    EventSystem cosa = EventSystem.current;
    //Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
    // Use this for initialization
    void Awake()
    {
        GameObject.Find("Inventario").GetComponent<Canvas>().enabled = false;
        mochila = new Mochila() ;
        foreach (Transform hijo in gameObject.transform)
        {
            if (hijo.name == "Button_info") hijo.gameObject.SetActive(false);
            else if (hijo.name == "Button_usar") hijo.gameObject.SetActive(false);
            else if (hijo.name == "SubMenu") hijo.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) && !mostrarMenu && GameObject.Find("MenuPausa").GetComponent<Pausa>().juegoPausado == false) mostrarInv();
        else if (Input.GetKeyDown(KeyCode.I) && mostrarMenu) salir();
        else if (SubObj && Input.GetKeyDown(KeyCode.Escape)) salirObj();
        else if (Input.GetKeyDown(KeyCode.Escape) && mostrarMenu && SubMenu) salirSubMenu();
        else if (Input.GetKeyDown(KeyCode.Escape) && mostrarMenu) salir();
        else if (SubMenu && Input.GetKeyDown(KeyCode.Return))
        {
            switch (posicionSub)
            {
                default: mostrarObj(mochila.getObjetos()[0]);
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) && mostrarMenu && mochila.peso > 0f) mostrarSubMenu();
        else if (SubMenu && Input.GetKeyDown(KeyCode.Return)){
            switch (posicionSub)
            {
                default : mostrarObj(mochila.getObjetos()[0]);
                    break;
            }
        }
       
    }

    public void mostrarSubMenu()
    {
                  
            foreach (Transform hijo in gameObject.transform)
            {
                if (hijo.name == "Button_usar")
                {              
                    hijo.gameObject.SetActive(true);
                    try
                    {
                        cosa.SetSelectedGameObject(hijo.gameObject);
                    }
                    catch (System.Exception e) { }
                }
                else if (hijo.name == "Button_info")
                {
                    hijo.gameObject.SetActive(true);               

                }
                else if (hijo.name == "cursor") hijo.GetComponent<Animator>().SetBool("parado", true);
     
            }
            
            SubMenu = true;
    }

    public void salirSubMenu()
    {
        cosa.SetSelectedGameObject(null);
        foreach (Transform hijo in gameObject.transform)
        {
            if (hijo.name == "Button_info") hijo.gameObject.SetActive(false);
            if (hijo.name == "Button_usar") hijo.gameObject.SetActive(false);
            else if (hijo.name == "cursor") hijo.GetComponent<Animator>().SetBool("parado",false);
        }

        SubMenu = false;
    }


    public void mostrarInv()
    {
        mostrarMenu = !mostrarMenu;

        
        mochila = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>().mochila;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Girar>().enabled = false;
        GameObject.FindGameObjectWithTag("Enemigo").GetComponent<EneIA>().Parar();
        GameObject.FindGameObjectWithTag("Enemigo").GetComponent<EneIA>().enabled = false;
        GameObject.FindGameObjectWithTag("Enemigo").GetComponent<AudioSource>().enabled = false;

        gameObject.GetComponentsInChildren<Text>()[1].text = mochila.peso + " Kg";

        foreach(Objeto obj in mochila.getObjetos()){
            gameObject.GetComponentsInChildren<Text>()[2].text = obj.nombre;
            gameObject.GetComponentsInChildren<Image>()[1].sprite = obj.imagen;
        }

        
        GetComponent<Canvas>().enabled = true;

    }

    private void salir()
    {
        if (SubObj) salirObj();
        if (SubMenu) salirSubMenu();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Girar>().enabled = true;
        GameObject.FindGameObjectWithTag("Enemigo").GetComponent<EneIA>().enabled = true;
        GameObject.FindGameObjectWithTag("Enemigo").GetComponent<EneIA>().reiniciar();
        GameObject.FindGameObjectWithTag("Enemigo").GetComponent<AudioSource>().enabled = true;
        GetComponent<Canvas>().enabled = false;
        mostrarMenu = false;
        
    }

    private void mostrarObj(Objeto obj)
    {
        foreach (Transform hijo in gameObject.transform)
        {
            if (hijo.name == "SubMenu")
            {
                hijo.gameObject.SetActive(true);
                hijo.GetComponentsInChildren<Text>()[0].text = obj.nombre;
                hijo.GetComponentsInChildren<Text>()[1].text = obj.peso.ToString() + " Kg";
                hijo.GetComponentsInChildren<Text>()[2].text = obj.descripcion;
                obj.get3d().SetActive(true);

                gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
                gameObject.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>();
               // GameObject.Find("Edificio").SetActive(false);
              //  gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(-2.5f,0.2f,0);
              //  gameObject.transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
               // obj.get3d().transform.position = gameObject.transform.position - new Vector3(0,0,0.5f);
               // gameObject.transform.localScale = new Vector3(0.004f, 0.004f, 0.004f);
                //Application.LoadLevelAdditive("Prueba");
                
                //GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(20,20,20);
                break;
            }
        }
        SubObj = true;
    }

    private void salirObj()
    {
        foreach (Transform hijo in gameObject.transform)
        {
            if (hijo.name == "SubMenu")
            {
                hijo.gameObject.SetActive(false);
                gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                mochila.getObjetos()[0].get3d().SetActive(false);
                //GameObject.Find("Edificio").SetActive(true);
                //GameObject.FindGameObjectWithTag("Player").transform.position = pos;
                break;
            }
        }
        SubObj = false;
    }
}
