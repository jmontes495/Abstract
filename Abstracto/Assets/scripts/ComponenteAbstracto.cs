using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponenteAbstracto : MonoBehaviour {

    public delegate void Colision();
    public static event Colision RebotaHaciaAtras;
    public static event Colision AlcanzoObjetivo;
    public static event Colision SalidaObstaculo;

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
        else
        {
            RebotaHaciaAtras();
        }
    }
}
