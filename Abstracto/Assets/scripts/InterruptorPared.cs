using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorPared : MonoBehaviour {

    public GameObject pared;
	// Use this for initialization
	void Start () {
        JuegoManager.Reiniciar += reaparecer;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void desaparecer()
	{
        pared.SetActive(false);
        this.gameObject.SetActive(false);
	}

    void reaparecer()
    {
        this.gameObject.SetActive(true);
        pared.SetActive(true);
    }
}
