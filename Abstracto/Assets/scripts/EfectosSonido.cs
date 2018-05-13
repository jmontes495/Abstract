using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosSonido : MonoBehaviour
{

    AudioSource audioS;

    public AudioClip papel;

    public AudioClip golpe;


    // Use this for initialization
    void Awake()
    {
        audioS = GetComponent<AudioSource>();
        ComponenteAbstracto.SalidaObstaculo += reproducirPapel;
        ComponenteAbstracto.RebotaHaciaAtras += reproducirGolpe;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reproducirPapel()
    {
        audioS.clip = papel;
        audioS.Play();
    }

    public void reproducirGolpe()
    {
        audioS.clip = golpe;
        audioS.Play();
    }
}
