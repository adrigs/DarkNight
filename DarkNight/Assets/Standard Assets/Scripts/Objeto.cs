using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Objeto : MonoBehaviour {

    public string nombre;
    public float peso;
    public string descripcion;
    public int tipo;
    public Sprite imagen;
    private GameObject imagen3d;


    public Objeto(string n, float p, string d, int t,Sprite i)
    {
        nombre = n;
        peso = p;
        descripcion = d;
        tipo = t;
        imagen = i;
        imagen3d = null;
    }

    public void set3d(GameObject obj){
        imagen3d = obj;
    }

    public GameObject get3d()
    {
        return imagen3d;
    }
   
}
