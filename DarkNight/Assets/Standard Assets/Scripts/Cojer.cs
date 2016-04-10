using UnityEngine;
using System.Collections;

public class Cojer : MonoBehaviour {

    private Transform obj;
    private RaycastHit hit;
    private float dist;
    private Ray ray;
	
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKeyDown(KeyCode.E)) cojer();
	}
    
    private void cojer()
    {
        
       ray = GameObject.FindGameObjectWithTag("Player").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out hit)){
           obj = hit.transform;

           if( hit.transform.tag == "Pick"){                 
               
               if (estaDist(6f))
               {
                   Objeto objeto = GameObject.FindGameObjectWithTag("Pick").GetComponent<Objeto>();
                   GameObject objeto3d = GameObject.Instantiate(GameObject.FindGameObjectWithTag("Pick"));
                   Destroy(objeto3d.GetComponent<Objeto>());
                   Destroy(objeto3d.GetComponent<Animator>());
                   Destroy(objeto3d.GetComponent<Rigidbody>());
                   Destroy(objeto3d.GetComponent<SphereCollider>());
                   objeto3d.layer = LayerMask.NameToLayer("UI");
                   objeto3d.AddComponent<CanvasRenderer>();//TODO
                   objeto3d.SetActive(false);
                   objeto.set3d(objeto3d);
                   gameObject.GetComponent<Jugador>().mochila.add(objeto);
                   Destroy(GameObject.FindGameObjectWithTag("Pick"));
                   Pantalla.setTexto("Has recojido una esfera");
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
