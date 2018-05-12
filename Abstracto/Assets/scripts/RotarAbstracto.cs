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

        if (Input.GetKey(KeyCode.J))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            moveVertical = -1f;
        }

        float moveHorizontal = 0f;
        if (Input.GetKey(KeyCode.I))
        {
            moveHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            moveHorizontal = -1f;
        }
        transform.Rotate(moveHorizontal, moveVertical, 0f);
    }
}
