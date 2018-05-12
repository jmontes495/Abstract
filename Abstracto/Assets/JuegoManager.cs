using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuegoManager : MonoBehaviour {

    Text tiempo;

    int segundosRestantes;

    public delegate void Final();
    public static event Final TerminarJuego;
	// Use this for initialization
	void Start () {
        tiempo = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Text>();
        ComponenteAbstracto.AlcanzoObjetivo += MetaJuego;
        StartCoroutine("TranscurrirTiempo");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MetaJuego()
    {
        tiempo.text = "Ganaste";
        StopCoroutine("TranscurrirTiempo");
        TerminarJuego();
    }

    IEnumerator TranscurrirTiempo()
    {
        segundosRestantes = 30;
        while(segundosRestantes > 0)
        {
            string adicionMinutos = "";
            string adicionSegundos = "";
            if(segundosRestantes / 60 < 10)
            {
                adicionMinutos = "0";
            }
            if (segundosRestantes % 60 < 10)
            {
                adicionSegundos = "0";
            }

            tiempo.text = adicionMinutos + segundosRestantes / 60 + ":" + adicionSegundos + segundosRestantes % 60;
            segundosRestantes--;
            yield return new WaitForSeconds(1f);
        }
        tiempo.text = "00:00";
        TerminarJuego();
    }
}
