using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarAbstracto : MonoBehaviour {

    float speed = 1f;

    void Start () {

    }
	
    void FixedUpdate()
    {
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVertical = -1f;
        }

        float moveHorizontal = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveHorizontal = -1f;
        }

        float moveDiagonal = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            moveDiagonal = 1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveDiagonal = -1f;
        }
        transform.Rotate(moveHorizontal*speed, moveVertical*speed, moveDiagonal*speed);
    }
}
