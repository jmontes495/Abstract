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
        }
        else if (other.tag == "MuroIzq")
        {
            RebotaHaciaDerecha();
        }
        else if (other.tag == "MuroDer")
        {
            RebotaHaciaDerecha();
        }
        else if (other.tag == "MuroArriba")
        {
            RebotaHaciaAbajo();
        }
        else if (other.tag == "Inicio")
        {
            RebotaHaciaAdelante();
        }
        else
        {
            RebotaHaciaAtras();
        }
    }
}
