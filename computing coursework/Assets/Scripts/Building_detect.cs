using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_detect : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "road_perm" || other.gameObject.tag == "House")
        {
            Camera.main.SendMessage("collide_detecting", true);
        }
    }

    void FixedUpdate()
    {
        Camera.main.SendMessage("collide_detecting", false);
    }
}
