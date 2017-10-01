using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_detect : MonoBehaviour
{

    Collider collision;

    void OnTriggerEnter(Collider other)
    {
        collision = other;
        if (other.gameObject.tag == "road_perm" || other.gameObject.tag == "House")
        {
            Camera.main.SendMessage("collide_detecting", true);
        }
        else if (other.gameObject.tag == "Tree" && Input.GetMouseButtonDown(0))
        {
            Destroy(other.gameObject);
        }
    }

    void FixedUpdate()
    {

        if (collision != null)
        {
            if (collision.gameObject.tag == "road_perm" || collision.gameObject.tag == "House")
            {
                Camera.main.SendMessage("collide_detecting", true);
            }
        }
        else
        {
            Camera.main.SendMessage("collide_detecting", false);
        }
    }
}