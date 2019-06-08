using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlacarScript : MonoBehaviour {

    public static int pontos;
    public Text txtPlacar;

    private bool placarParado = true;

    private IEnumerator ContarPlacar()
    {
        yield return new WaitForSeconds(1);
        if (JogadorScript.jogando)
        {
            pontos++;
            if(pontos % 10 == 0)
            {
                PrincipalScript.velocidade = PrincipalScript.velocidade + 0.5f;
            }

            txtPlacar.text = pontos.ToString();
            StartCoroutine(ContarPlacar());
        }
    }

	// Use this for initialization
	void Start () {

        pontos = 0;

    }
	
	// Update is called once per frame
	void Update () {

        if(JogadorScript.jogando && placarParado == true)
        {

            StartCoroutine(ContarPlacar());
            placarParado = false;

        }
		
	}

}
