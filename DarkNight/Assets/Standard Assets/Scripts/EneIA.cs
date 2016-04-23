using UnityEngine;
using System.Collections;

public class EneIA : MonoBehaviour {


    bool parado;
    Transform jugador;
    NavMeshAgent nav;
    ParticleSystem par;
    public int vida;
    public bool muerto;
    public float counttt;
    public float timer;
   
    void Awake()
    {
        parado = false;
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        par = GetComponent<ParticleSystem>();
        vida = 50;
        muerto = false;
        counttt = 5f;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!parado) nav.SetDestination(jugador.position);
        if (muerto)
        {
            gameObject.transform.Rotate(new Vector3(0, 20F, 0));
            timer += Time.deltaTime;
            if (counttt <= timer) gameObject.SetActive(false);
        }
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

    public void recibirDano()
    {
        par.Play();
        vida -= 1;
        if (vida <= 0) morir();
    }

    public void morir()
    {
        Parar();
        GetComponent<AudioSource>().enabled = false;
        GetComponent<EneAtaque>().enabled = false;
        muerto = true;
        GameObject.Find("eso").transform.position = gameObject.transform.position;
        GameObject.Find("eso").GetComponent<ParticleSystem>().Play();
    }
}
