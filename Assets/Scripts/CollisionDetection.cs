using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour
{
    

    void OnCollisionEnter(Collision collisionInfo)
    {
        print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
        print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
        print("Their relative velocity is " + collisionInfo.relativeVelocity);


        if (collisionInfo.collider.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            print("ENVIRONMENT HIT");

            foreach (ContactPoint contact in collisionInfo.contacts)
            {
                DrawHit(contact);
            }
        }

        GetComponent<VertsEditor>().VertsColor(collisionInfo.gameObject);



    }

    void OnCollisionStay(Collision collisionInfo)
    {
        //print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");

        // var contact = collisionInfo.contacts[0];
        //print("Contact point is " + contact.point); //this is the Vector3 position of the point of contact

        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            DrawHit(contact);
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        print(gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
    }

    void DrawHit(ContactPoint contact)
    {
        Debug.DrawRay(contact.point, contact.normal, Color.red, 10);


        if (HasLineOfSight(contact.point, gameObject))
        {
            // Visualize the contact point
            Debug.DrawRay(contact.point, contact.normal, Color.red, 10);
        }

        //var mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //mySphere.transform.localScale = new Vector3(4, 4, 4);
        //mySphere.GetComponent<Renderer>().material.color = new Color(250, 0, 0, 1);
        //mySphere.transform.position = pos;

        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(pos, 1);
    }

    bool HasLineOfSight(Vector3 target, GameObject source)
    {
        var hit = new RaycastHit();
        var rayDirection = source.transform.position - target;
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            if (hit.transform == source.transform)
            {
                print("There is line of sight!!!");
                // enemy can see the player!
                return true;
            }
            else
            {
                print("No line of sight...");
                // there is something obstructing the view
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}