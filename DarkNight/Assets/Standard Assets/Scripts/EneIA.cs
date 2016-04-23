using UnityEngine;
using System.Collections;

public class EneIA : MonoBehaviour {


    bool parado;
    Transform jugador;
    NavMeshAgent nav;
   
    void Awake()
    {
        parado = false;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!parado) nav.SetDestination(jugador.position);
    }

    public void Parar()
    {
        parado = true;
        nav.enabled = false;
    }

    public void reiniciar()
    {
        parado = false;
        nav.enabled = true;
    }
}
