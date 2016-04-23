using UnityEngine;
using System.Collections;

public class Girar : MonoBehaviour {

	// Use this for initialization
    float cam1 = 0.0f;
    float cam2 = 0.0f;
    float velocidadGiro = 3f;

	// Update is called once per frame
	void Update () {
        cam1 += velocidadGiro * Input.GetAxis("Mouse X");
        float nuevo = velocidadGiro * Input.GetAxis("Mouse Y");
        if(cam2 < 35f && nuevo > 0) cam2 += nuevo;
        else if (cam2 > -35f && nuevo < 0) cam2 += nuevo;
        
        transform.eulerAngles = new Vector3(cam2 * -1, cam1, 0.0f);
        
	}
}
