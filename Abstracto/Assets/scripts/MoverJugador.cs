using System.Collections;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
    float speed = 5f;

    Rigidbody rb;

    bool enMarcha = true;


    // Use this for initialization
    void Start()
    {
        ComponenteAbstracto.RebotaHaciaAtras += Rebote;
        JuegoManager.TerminarJuego += TerminarJuego;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (enMarcha)
        {
            float adelante = 0f;
            if (Input.GetKey(KeyCode.Space))
            {
                adelante = 1f;
            }

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.1f + adelante);
            rb.velocity = movement * speed;
        }
    }

    public void Rebote()
    {
        if(enMarcha)
        {
            enMarcha = false;
            rb.velocity = new Vector3(0, 0, 0);
            Vector3 setback = new Vector3(0.0f, 0.0f, -100.0f);

            rb.AddForce(setback);
            StartCoroutine("HaciaAtras");
        }

    }

    public void TerminarJuego()
    {
        rb.velocity = new Vector3(0, 0, 0);
        enMarcha = false;
    }

    private IEnumerator HaciaAtras()
    {
        int contador = 0;
        while (contador < 5)
        {
            rb.AddForce(new Vector3(0, 0, 20));
            contador++;
            yield return new WaitForSeconds(0.1f);
        }
        enMarcha = true;
    }


}