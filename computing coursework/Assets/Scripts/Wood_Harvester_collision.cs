﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Harvester_collision : MonoBehaviour {

    List<Collider> collision = new List<Collider>();

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree")
        {
            collision.Add(other);
        }

        foreach (Collider col_object in collision)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(col_object.gameObject);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 74918ef8aa9e8421ea05e26a4be509be5bb61d5a
