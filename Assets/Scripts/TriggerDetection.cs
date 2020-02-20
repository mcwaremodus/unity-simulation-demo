using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print("Collision detected with trigger object " + other.name);
    }

    void OnTriggerStay(Collider other)
    {
        print("Still colliding with trigger object " + other.name);
    }

    void OnTriggerExit(Collider other)
    {
        print(gameObject.name + " and trigger object " + other.name + " are no longer colliding");
    }
}
