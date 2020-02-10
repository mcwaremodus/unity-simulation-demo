using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabreHandler : MonoBehaviour
{

    Vector3 posInput;
    Vector3 rotInput;

    bool powered = true;
    float speed = 150;

    public void MoveInput (Vector3 move, Vector3 rote, bool power)
    {
        posInput = move;
        rotInput = rote;
        powered = power;

        ActuallyMove();
    }

    void ActuallyMove()
    {
        if (powered)
        {
            speed = 150;
        }
        else
        {
            speed = 0;
            GetComponent<Rigidbody>().drag = 0;
        }

        GetComponent<Rigidbody>().AddRelativeForce(posInput * speed);
        GetComponent<Rigidbody>().AddRelativeTorque(rotInput);
    }
}
