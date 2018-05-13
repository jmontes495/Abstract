using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarAbstracto : MonoBehaviour {

    float speed = 1f;

    bool enTranscurso;

    void Start () {
        JuegoManager.Reiniciar += reiniciar;
        JuegoManager.TerminarJuego += terminar;
        enTranscurso = true;
    }
	
    void terminar()
    {
        enTranscurso = false;    
    }

    void FixedUpdate()
    {
        if(enTranscurso)
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
            transform.Rotate(moveHorizontal * speed, moveVertical * speed, moveDiagonal * speed);
        }
    }

    void reiniciar()
    {
        enTranscurso = true;
        transform.rotation = Quaternion.identity;
    }
}
