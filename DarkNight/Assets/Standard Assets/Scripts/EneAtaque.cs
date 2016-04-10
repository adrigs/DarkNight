using UnityEngine;
using System.Collections;

public class EneAtaque : MonoBehaviour {

    
    GameObject jugador;
    bool jugadorEnRango;
    AudioSource audio;
    EneIA mov;
    public AudioClip sonido;

	// Use this for initialization
	void Awake () {
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugadorEnRango = false;
        audio = GetComponent<AudioSource>();
        mov = GetComponent<EneIA>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (jugadorEnRango) Atacar();
	}

    void OnTriggerEnter(Collider otro)
    {
        if (otro.gameObject == jugador)
        {
            jugadorEnRango = true;
        }
    }

    void OnTriggerExit(Collider otro)
    {
        if (otro.gameObject == jugador)
        {
            jugadorEnRango = false;
        }
    }

    void Atacar()
    {
        mov.Parar();
        audio.enabled = true;
        audio.loop = false;
        audio.playOnAwake = false;
        audio.clip = sonido;        
        audio.Play();
        jugador.GetComponent<Jugador>().Morir();
    }
}
