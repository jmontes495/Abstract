using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcularFinal : MonoBehaviour {

    float distancia = 0f;
    float maximo = 0f;
    GameObject jugador;
    AudioSource elSource;
	// Use this for initialization
	void Start () {
        jugador = GameObject.FindWithTag("Player");
        elSource = GetComponent<AudioSource>();
        maximo = (jugador.gameObject.transform.position.z - this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        distancia = (jugador.gameObject.transform.position.z - this.transform.position.z) - maximo;
        elSource.volume = distancia*0.0005f;
	}
}
