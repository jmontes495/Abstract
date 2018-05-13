using System.Collections;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
    float speed = 5f;

    Rigidbody rb;

    bool enMarcha = true;

    bool detener = false;

    Vector3 posInicial;


    // Use this for initialization
    void Awake()
    {
        ComponenteAbstracto.RebotaHaciaAtras += Rebote;
        ComponenteAbstracto.RebotaHaciaArriba += ReboteHaciaArriba;
        ComponenteAbstracto.RebotaHaciaDerecha += ReboteHaciaDerecha;
        ComponenteAbstracto.RebotaHaciaIzquierda += ReboteHaciaIzquierda;
        ComponenteAbstracto.RebotaHaciaAbajo += ReboteHaciaAbajo;
        ComponenteAbstracto.RebotaHaciaAdelante += ReboteHaciaAdelante;
        JuegoManager.TerminarJuego += TerminarJuego;
        JuegoManager.Reiniciar += Reiniciar;
        rb = GetComponent<Rigidbody>();
        posInicial = transform.position;
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
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                adelante = -1f;
            }

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, adelante);
            rb.velocity = movement * speed;
        }
    }

    void Reiniciar()
    {
        enMarcha = true;
        detener = false;
        transform.position = posInicial;
    }

    //----------------------------------------------------------------------------------------------------------------
    // Rebotes

    public void Rebote()
    {
        if(enMarcha)
        {
            enMarcha = false;
            rb.velocity = Vector3.zero;
            Vector3 setback = new Vector3(0.0f, 0.0f, -100.0f);

            rb.AddForce(setback);
            StartCoroutine("HaciaAtras");
        }

    }

    public void ReboteHaciaAdelante()
    {
        if (enMarcha)
        {
            enMarcha = false;
            rb.velocity = Vector3.zero;
            Vector3 setback = new Vector3(0.0f, 0.0f, 100.0f);

            rb.AddForce(setback);
            StartCoroutine("HaciaAdelante");
        }

    }

    public void ReboteHaciaArriba()
    {
        if (enMarcha)
        {
            enMarcha = false;
            rb.velocity = Vector3.zero;
            Vector3 setback = new Vector3(0.0f, 100.0f, 0.0f);

            rb.AddForce(setback);
            StartCoroutine("HaciaArriba");
        }
    }

    public void ReboteHaciaAbajo()
    {
        if (enMarcha)
        {
            enMarcha = false;
            rb.velocity = Vector3.zero;
            Vector3 setback = new Vector3(0.0f, -100.0f, 0.0f);

            rb.AddForce(setback);
            StartCoroutine("HaciaAbajo");
        }
    }

    public void ReboteHaciaDerecha()
    {
        if (enMarcha)
        {
            enMarcha = false;
            rb.velocity = Vector3.zero;
            Vector3 setback = new Vector3(-100.0f, 0.0f, 0.0f);

            rb.AddForce(setback);
            StartCoroutine("HaciaDerecha");
        }
    }

    public void ReboteHaciaIzquierda()
    {
        if (enMarcha)
        {
            enMarcha = false;
            rb.velocity = Vector3.zero;
            Vector3 setback = new Vector3(100.0f, 0.0f, 0.0f);

            rb.AddForce(setback);
            StartCoroutine("HaciaIzquierda");
        }
    }

    //----------------------------------------------------------------------------------------------------------------

    public void TerminarJuego()
    {
        enMarcha = false;
        detener = true;
        rb.velocity = Vector3.zero;
    }


    //-----------------------------------------------------------------------------------------------------------------
    // Desaceleradores
    private IEnumerator HaciaAtras()
    {
        int contador = 0;
        while (contador < 5)
        {
            rb.AddForce(new Vector3(0, 0, 20));
            contador++;
            yield return new WaitForSeconds(0.1f);
        }
        if(!detener)
        {
            enMarcha = true;
        }
    }

    private IEnumerator HaciaAdelante()
    {
        int contador = 0;
        while (contador < 5)
        {
            rb.AddForce(new Vector3(0, 0, -20));
            contador++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!detener)
        {
            enMarcha = true;
        }
    }

    private IEnumerator HaciaArriba()
    {
        int contador = 0;
        while (contador < 5)
        {
            rb.AddForce(new Vector3(0, -20, 0));
            contador++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!detener)
        {
            enMarcha = true;
        }
    }

    private IEnumerator HaciaAbajo()
    {
        int contador = 0;
        while (contador < 5)
        {
            rb.AddForce(new Vector3(0, 20, 0));
            contador++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!detener)
        {
            enMarcha = true;
        }
    }

    private IEnumerator HaciaDerecha()
    {
        int contador = 0;
        while (contador < 5)
        {
            rb.AddForce(new Vector3(20, 0, 0));
            contador++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!detener)
        {
            enMarcha = true;
        }
    }

    private IEnumerator HaciaIzquierda()
    {
        int contador = 0;
        while (contador < 5)
        {
            rb.AddForce(new Vector3(-20, 0, 0));
            contador++;
            yield return new WaitForSeconds(0.1f);
        }
        if (!detener)
        {
            enMarcha = true;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------

}