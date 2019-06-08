using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorScript : MonoBehaviour {
    
    public float impulso;
    public Transform sensorChao;
    public static bool jogando;
    public AudioClip[] clips;
    public GameObject destroyFXPrefab;

    private bool estaNoChao;
    private bool impulsionar;

    private Rigidbody2D rb2d;
    private Animator anima;
    private AudioSource som;

	// Use this for initialization
	void Start () {

        // interface de acesso aos componentes
        rb2d = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        som = GetComponent<AudioSource>();

        // sinaliza que o jogo não iniciou
        jogando = false;

    }
	
    // CPU
	// Update is called once per frame
    // Inputs
	void Update () {

        // Exemplo de pause

        if(Input.touchCount == 2)
        {

            if(Time.timeScale == 0)
            {
                Time.timeScale = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
            }

        }

        // Verificação de colisão com o chão
        estaNoChao = Physics2D.Linecast(transform.position, sensorChao.position,
                                        1 << LayerMask.NameToLayer("Chao"));
        
        // Touch na tela... clique do mouse... e ctrl esquerdo...
        if (Input.GetButtonDown("Fire1") && estaNoChao)
        {
            // Altera o estado do jogo...
            if(jogando == false)
            {
                PrincipalScript.Start();
                // Inicia o jogo
                jogando = true;
                // Sai da animação Idle para Run
                anima.SetBool("pJogando", jogando);
                // Chama a coroutine do placar

            }            
            else
            { 
                // altera o estado para executar o pulo
                impulsionar = true;
            }
        }

        // Animação de corrido
        anima.SetBool("pNoChao", estaNoChao);

    }

    // GPU
    void FixedUpdate ()
    {
        
        // Ação do pulo
        if (impulsionar)
        {
            // Carrega o som do pulo
            som.clip = clips[0];
            som.Play();

            // Executa o pulo
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * impulso);
            impulsionar = false;

        }
        
    }

    void OnCollisionEnter2D(Collision2D c)
    {

        //print(c.gameObject.tag);         
        if(c.gameObject.tag == "Obstaculo")
        {

            // Carrega o som da morte
            som.clip = clips[1];
            som.Play();
            jogando = false;

            GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(destroyFXPrefab, transform.position, transform.rotation);
            

            StartCoroutine(DestruirPersonagem());

        }
        
    }

    IEnumerator DestruirPersonagem()
    {

        yield return new WaitForSeconds(0.3f);

        //Destroy(gameObject);        
        SceneManager.LoadScene("GameScene");

    }

}
