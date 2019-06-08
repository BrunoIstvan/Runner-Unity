using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncoraScript : MonoBehaviour
{

    //public float velocidade;
    public float limiteX, retornoX;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(JogadorScript.jogando)
        { 

            if(transform.position.x < limiteX)
            {

                transform.position = new Vector2(retornoX, transform.position.y);

            }

            transform.Translate(Vector2.left * PrincipalScript.velocidade * Time.deltaTime);

        }

    }

    void FixedUpdate()
    {
        
    }

}
