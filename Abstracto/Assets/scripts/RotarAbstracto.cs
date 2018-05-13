using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarAbstracto : MonoBehaviour {

    float speed = 5f;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
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
        transform.Rotate(moveHorizontal, moveVertical, 0f);
    }
}
