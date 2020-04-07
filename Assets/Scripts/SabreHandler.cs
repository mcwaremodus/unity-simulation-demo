using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabreHandler : MonoBehaviour
{

    Vector3 posInput;
    Vector3 rotInput;

    bool powered = true;
    float speed = 20;


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
            speed = 60;
        }
        else
        {
            speed = 0;
            GetComponent<Rigidbody>().drag = 0;
        }

        GetComponent<Rigidbody>().AddRelativeForce(posInput * speed);
        GetComponent<Rigidbody>().AddRelativeTorque(rotInput);
    }

    IEnumerator MoveTo(Transform mover, Vector3 destination, float speed)
    {        
        print("Moving to position: " + destination);
        //mover.Rotate(0, 90, 0);
        // This looks unsafe, but Unity uses
        // en epsilon when comparing vectors.
        while (Vector3.SqrMagnitude(mover.position - destination) > 0.001)
        {
            Debug.Log(Vector3.SqrMagnitude(mover.position - destination));
            Debug.Log(mover.position);
            Debug.Log(destination);
            mover.position = Vector3.MoveTowards(
                mover.position,
                destination,
                speed * Time.deltaTime);
            // Wait a frame and move again.
            yield return null;
        }
        Debug.Log(destination + " reached. Route Completed.");
        routeCompleted = true;
    }

    private void Update()
    {
        if (routeCompleted) {
            if (routeQueue.Count > 0) {
                routeCompleted = false;
                Vector3 target = routeQueue.Dequeue();
                StartCoroutine(MoveTo(transform, target, routeSpeed));

            }
            else {
                Debug.Log("No other routes in queue.");
            }
        }
    }

    bool routeCompleted = true;
    Queue<Vector3> routeQueue = new Queue<Vector3>();
    int routeSpeed = 0;
    //public Transform target;
    public void MoveToPosition(Vector3 position, int speed)
    {
        routeSpeed = 100;
        routeQueue.Enqueue(position);

        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, position, step);
    }
}
