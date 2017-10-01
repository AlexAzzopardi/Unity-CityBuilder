using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movements : MonoBehaviour {

    public float turn_Speed;
    public float thrust;

    public Rigidbody rb;

    void Start()
    {

    }

    void FixedUpdate()
    {
        
        if (Input.GetKey("q") == true)
        {
            transform.Rotate(Vector3.up, turn_Speed * Time.deltaTime);
        }

        if (Input.GetKey("e") == true)
        {
            transform.Rotate(Vector3.up, -turn_Speed * Time.deltaTime);
        }

        if (Input.GetKey("d") == true)
        {
            rb.AddForce(transform.right * thrust);
        }
        if (Input.GetKey("a") == true)
        {
            rb.AddForce(transform.right * -thrust);
        }
        if (Input.GetKey("w") == true)
        {
            rb.AddForce(transform.forward * thrust);
        }
        if (Input.GetKey("s") == true)
        {
            rb.AddForce(transform.forward * -thrust);
        }
    }
}
