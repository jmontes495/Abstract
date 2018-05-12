using System.Collections;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
    float speed = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float adelante = 0f;
        if(Input.GetKey(KeyCode.Space))
        {
            adelante = 1f;
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            adelante = -1f;
        }

        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, moveVertical,adelante);
        rb.velocity = movement * speed; 
    }
}