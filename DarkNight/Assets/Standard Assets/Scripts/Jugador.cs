using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Jugador : MonoBehaviour {

    public bool muerto;
    Animator anim;
    Movimiento movimiento;
    float tiempoParaMorir = 2f;
    float timer;
    public Mochila mochila;
    
	// Use this for initialization
	void Awake () {
	    muerto = false;
        anim = GetComponent<Animator>();
        movimiento = GetComponent<Movimiento>();
        mochila = new Mochila();
        //mochila.add(new Objeto("Joya antigua", 0.1f,"Una joya antigua de mi familia.", 0, null));
	}
	
	// Update is called once per frame
	void Update () {
        
	    if(muerto){
            timer += Time.deltaTime;
            if(timer >= tiempoParaMorir) Menu.onMuertoMenu();
           // damageImage.color =flashColour;
       }
      //  else{
      //      damageImage.color = Color.Lerp(damageImage.color, Color.clear,flashSpeed * Time.deltaTime);
      //  }
        
	}

    public void Morir()
    {
        anim.enabled = true;
        muerto = true;
        anim.SetTrigger("Morir");
        //playerAudio.Play();
        movimiento.enabled = false;
       
    }
}
