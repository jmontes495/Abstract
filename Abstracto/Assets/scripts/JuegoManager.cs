﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JuegoManager : MonoBehaviour {

    Text tiempo;

    int segundosRestantes;

    bool enTranscurso;

    public delegate void Final();
    public static event Final TerminarJuego;
    public static event Final Reiniciar;
	// Use this for initialization
	void Awake () {
        tiempo = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Text>();
        ComponenteAbstracto.AlcanzoObjetivo += MetaJuego;
        StartCoroutine("TranscurrirTiempo");
	}
	
	// Update is called once per frame
	void Update () {
        if (!enTranscurso && Input.GetKeyDown(KeyCode.Space))
        {
            Reiniciar();
            StartCoroutine("TranscurrirTiempo");
        }
	}

    public void MetaJuego()
    {
        tiempo.text = "You Win";
        StopCoroutine("TranscurrirTiempo");
        enTranscurso = false;
        TerminarJuego();
    }

    IEnumerator TranscurrirTiempo()
    {
        segundosRestantes = 10;
        enTranscurso = true;
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
        tiempo.text = "game over - press space to replay";
        enTranscurso = false;
        TerminarJuego();
    }
}
