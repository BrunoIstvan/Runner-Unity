using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomFundoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        if(JogadorScript.jogando)
        {
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }

	}
}
