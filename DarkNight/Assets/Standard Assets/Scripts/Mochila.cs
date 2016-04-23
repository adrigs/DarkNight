using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mochila  {

    private List<Objeto> objetos;
    public float peso;

    public Mochila()
    {
        peso = 0f;
        objetos = new List<Objeto>();
    }

    public void add(Objeto obj) {
        objetos.Add(obj);
        peso += obj.peso;
    }

    public List<Objeto> getObjetos()
    {
        return objetos;
    }
}
