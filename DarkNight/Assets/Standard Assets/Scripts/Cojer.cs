using UnityEngine;
using System.Collections;

public class Cojer : MonoBehaviour {

    private Transform obj;
    private RaycastHit hit;
    private float dist;
    private Ray ray;
    public bool encendido = false;
    Light luz;

    void Awake()
    {
        luz = gameObject.GetComponent<Light>();
        luz.enabled = false;
    }
	
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E)) cojer();
        else if (Input.GetKeyDown(KeyCode.F)) encender();
        if (encendido) alumbrar();
	}

    public void encender()
    {
        if (!encendido)
        {
            luz.enabled = true;
            encendido = true;
        }
        else
        {
            luz.enabled = false;
            encendido = false;
            
        }
    }

    private void alumbrar()
    {
        Camera camera = gameObject.GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        ray = camera.ScreenPointToRay(Input.mousePosition);
        
       
        if (Physics.Raycast(ray, out hit))
        {
            obj = hit.transform;
            if (hit.transform.tag == "Enemigo")
            {
                //Debug.Log(Vector3.Distance(obj.position,gameObject.transform.position) + " " + Input.mousePosition);
               if(estaDist(30f) && !obj.GetComponent<EneIA>().muerto) hit.transform.gameObject.GetComponent<EneIA>().recibirDano();
               
            }
        }


    }

    private void cojer()
    {
        
       ray = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out hit)){
           obj = hit.transform;

           if( hit.transform.tag == "Pick"){                 
               
               if (estaDist(6f))
               {
                   Objeto objeto = obj.GetComponent<Objeto>();
                   GameObject objeto3d = GameObject.Instantiate(obj.gameObject);
                   Destroy(objeto3d.GetComponent<Objeto>());
                   Destroy(objeto3d.GetComponent<Animator>());
                   Destroy(objeto3d.GetComponent<Rigidbody>());
                   Destroy(objeto3d.GetComponent<SphereCollider>());
                   objeto3d.SetActive(false);
                   objeto.set3d(objeto3d);
                   gameObject.GetComponent<Jugador>().mochila.add(objeto);
                   Destroy(obj.transform.gameObject);
                   Pantalla.setTexto("Has recogido " + objeto.nombre);
               }
               else Debug.Log("No destruir");
          }
           else if(hit.transform.tag == "Guardar"){
               if (estaDist(5f))
               {
                   Datos.SetHayDatos(true);
                   Pantalla.setTexto("Has guardado partida");
               }
          }
       }
    }

     private bool estaDist(float min){
         dist = Vector3.Distance(obj.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>().transform.position);
         return (dist < min);
     }

       
    
}
