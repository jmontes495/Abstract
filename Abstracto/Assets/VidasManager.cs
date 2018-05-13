using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasManager : MonoBehaviour {

    public delegate void SinVidas();
    public static event SinVidas JugadorSinVidas;

    Image[] corazones;
    int vidas;
    bool pausa;
	// Use this for initialization
	void Start () {
        corazones = GetComponentsInChildren<Image>();
        vidas = 5;
        JuegoManager.Reiniciar += Reiniciar;
        ComponenteAbstracto.RecibeGolpe += PerderVida;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Reiniciar()
    {
        foreach(Image corazon in corazones)
        {
            corazon.enabled = true;
        }
        vidas = 5;
    }

    void PerderVida()
    {
        if(!pausa && vidas >= 1)
        {
            StartCoroutine("Delay");
            corazones[vidas - 1].enabled = false;
            vidas--;
            if (vidas == 0)
            {
                JugadorSinVidas();
            }
        }
    }

    private IEnumerator Delay()
    {
        pausa = true;
        yield return new WaitForSeconds(0.5f);
        pausa = false;
    }
}
