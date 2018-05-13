using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponenteAbstracto : MonoBehaviour {

    public delegate void Colision();
    public static event Colision RebotaHaciaAtras;
    public static event Colision AlcanzoObjetivo;
    public static event Colision SalidaObstaculo;
    public static event Colision RebotaHaciaArriba;
    public static event Colision RebotaHaciaDerecha;
    public static event Colision RebotaHaciaIzquierda;
    public static event Colision RebotaHaciaAbajo;
    public static event Colision RebotaHaciaAdelante;
    public static event Colision RecibeGolpe;



    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Objetivo")
        {
            AlcanzoObjetivo();
        }
        else if (other.tag == "Limite")
        {
            other.GetComponent<InterruptorPared>().desaparecer();
            SalidaObstaculo();
        }
        else if(other.tag == "Piso")
        {
            RebotaHaciaArriba();
            RecibeGolpe();
        }
        else if (other.tag == "MuroIzq")
        {
            RebotaHaciaDerecha();
            RecibeGolpe();

        }
        else if (other.tag == "MuroDer")
        {
            RebotaHaciaDerecha();
            RecibeGolpe();

        }
        else if (other.tag == "MuroArriba")
        {
            RebotaHaciaAbajo();
            RecibeGolpe();

        }
        else if (other.tag == "Inicio")
        {
            RebotaHaciaAdelante();

        }
        else
        {
            RebotaHaciaAtras();
            RecibeGolpe();
        }
    }
}
