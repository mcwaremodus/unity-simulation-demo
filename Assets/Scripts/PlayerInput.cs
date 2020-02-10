using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    SabreHandler sHand;

    Vector3 moveInput;
    Vector3 rotInput;

    bool powered = true;

    // Start is called before the first frame update
    void Start()
    {
        sHand = GetComponent<SabreHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        // Receive input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float u = Input.GetAxisRaw("Custom");

        float rh = Input.GetAxisRaw("Mouse X");
        float rv = Input.GetAxisRaw("Mouse Y");
        float ru = Input.GetAxisRaw("Steve");

        moveInput = new Vector3(h, u, v);
        rotInput = new Vector3(rv, rh, ru);

        if (Input.GetKeyDown(KeyCode.P))
        {
            powered = !powered;
        }


    }

    void FixedUpdate()
    {
        // Send input
        sHand.MoveInput(moveInput, rotInput, powered);
    }
}
