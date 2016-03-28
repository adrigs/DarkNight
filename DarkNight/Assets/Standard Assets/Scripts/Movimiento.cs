using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

    public float velocidad = 6f;

    Rigidbody playerRigibody;
    Vector3 movimiento;
    int floorMask;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigibody = GetComponent<Rigidbody>();
    }
	
	
	// Update is called once per frame
	void FixedUpdate () {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Mover(h, v);
        Girar();
	}

    private void Mover(float h, float v)
    {
        movimiento.Set(h, 0f, v);
        movimiento = movimiento.normalized * velocidad * Time.deltaTime;

        playerRigibody.MovePosition(transform.position + movimiento);
    }

    private void Girar()
    {


    }
}
