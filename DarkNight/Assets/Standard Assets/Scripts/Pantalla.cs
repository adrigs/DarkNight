using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pantalla : MonoBehaviour {

    private static string texto;
    private string last_texto;
    float time;
    float time_wait;
    private static bool ahora = false;

    public void Awake(){
        texto = "";
        last_texto = "";
        time = 0f;
        time_wait = 5f;
    }

    public void Update()
    {
        time += Time.deltaTime;
        if(ahora) {
            escribir();
            ahora = false;
        }
        if (time >= time_wait)
        {
            if (texto != last_texto) escribir();
            else Clear();
            time = 0f;
        }
    }
    public  void escribir()
    {
        last_texto = texto;
        gameObject.GetComponent<Text>().text = texto;

    }

    public static void setTexto(string texto2)
    {
        texto = texto2;
        ahora = true;
    }

    public void Clear()
    {
        gameObject.GetComponent<Text>().text = "";
    }
}
