using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movimiento : MonoBehaviour {

    public float velocidad = 6f;

    //Rigidbody playerRigibody;
    Vector3 movimiento;
    CharacterController playerController;
    bool puedeCorrer;
    float resistencia;
    Slider barra;
    GameObject obj;
    Jugador peso ;

    void Awake()
    {
        
        //playerRigibody = GetComponent<Rigidbody>();
        playerController = GetComponent<CharacterController>();
        resistencia = 100f;
        puedeCorrer = true;
        obj = GameObject.FindGameObjectWithTag("BarraRest");
        barra = obj.GetComponent<Slider>();
        peso = GetComponent<Jugador>();
       
    }
	
	
	// Update is called once per frame
	void FixedUpdate () {

        float lentitud = 1f;
        if (peso.mochila.peso >= 30f) lentitud = 0.5f;
        else if (peso.mochila.peso >= 20f) lentitud = 0.8f;

        resistencia = barra.value;
        if (resistencia == 100f)
        {
            obj.SetActive(false);
        }
        else if (resistencia < 100f && obj.activeSelf == false) obj.SetActive(true);
        if (resistencia == 0) puedeCorrer = false;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetAxis("Correr") > 0 && v > 0 && resistencia > 0f && puedeCorrer)
        {
            velocidad = 14f;
            barra.value -= 0.25f;
            if (barra.value <= 15f) barra.fillRect.GetComponent<Image>().color = Color.red;
            else if (barra.value <= 50f) barra.fillRect.GetComponent<Image>().color = Color.yellow;
           
        }
        else
        {
            velocidad = 6f;
            if (puedeCorrer) barra.value += 0.5f;
            else barra.value += 0.15f;

            if (barra.value >= 50f) barra.fillRect.GetComponent<Image>().color = Color.white;

            else if (barra.value >= 30f) puedeCorrer = true;

            else if (barra.value >= 15f) barra.fillRect.GetComponent<Image>().color = Color.yellow;
            
        }

        if (!puedeCorrer) velocidad = 1f;
        else velocidad *= lentitud;

        Debug.Log(velocidad);
        Mover(h, v);
        
	}

    private void Mover(float h, float v)
    {
          
            movimiento = new Vector3(Input.GetAxis("Horizontal"), 0,
                                    Input.GetAxis("Vertical"));
            movimiento = transform.TransformDirection(movimiento);
            movimiento *= velocidad;
            playerController.Move(movimiento * Time.deltaTime);

            // movimiento.Set(h , 0f, v );
            // movimiento = movimiento.normalized * velocidad * Time.deltaTime;

            // playerRigibody.MovePosition(transform.position + movimiento);        
    }

    
}
