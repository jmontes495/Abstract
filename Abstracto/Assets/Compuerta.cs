using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compuerta : MonoBehaviour {

    Vector3 referencia;

    float duracion = 0.1f;

	// Use this for initialization
	void Start () {
        referencia = transform.localScale;
        StartCoroutine("Abrir");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Abrir()
    {
        while(transform.localScale != Vector3.zero)
        {
            gameObject.transform.localScale = Vector3.MoveTowards(gameObject.transform.localScale, Vector3.zero, Time.fixedDeltaTime * 10f);
            yield return new WaitForSeconds(duracion);
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine("Cerrar");
    }

    private IEnumerator Cerrar()
    {
        while (transform.localScale != referencia)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, referencia, Time.fixedDeltaTime * 10f);
            yield return new WaitForSeconds(duracion);
        }
        yield return new WaitForSeconds(5f);
        StartCoroutine("Abrir");
    }
}
