using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public  class Menu : MonoBehaviour {

    public static int escenaCargar = 0;
    public void Awake()
    {
        if (!Datos.GetHayDatos() && SceneManager.GetActiveScene().name == "MenuInicio") 
            GameObject.FindGameObjectWithTag("Guardar").SetActive(false);
    }
    public  void onClickEmpezar() { 
       // SceneManager.LoadScene("EscenaInicial");
        SceneManager.LoadScene("PantallaCarga");
        escenaCargar = 1;
        Cursor.visible = false;
    }

    public  void onClickSalir()
    {
        Application.Quit();       
    }

    public  void onClickMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MenuInicio");
    }

    public static void onMuertoMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Muerte");
    }
}
