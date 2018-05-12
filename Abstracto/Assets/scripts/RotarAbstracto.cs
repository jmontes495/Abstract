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
        float moveHorizontal = 0f;

        if (Input.GetKey(KeyCode.J))
        {
            moveHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            moveHorizontal = -1f;
        }

        float moveVertical = 0f;
        if (Input.GetKey(KeyCode.I))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            moveVertical = -1f;
        }
        transform.Rotate(moveHorizontal, moveVertical, 0f);
    }
}
