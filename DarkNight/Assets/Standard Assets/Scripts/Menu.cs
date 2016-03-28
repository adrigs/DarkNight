using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
        
    public void onClickEmpezar() { 
        SceneManager.LoadScene("EscenaInicial");
    }

    public void onClickSalir()
    {
        Application.Quit();       
    }
}
