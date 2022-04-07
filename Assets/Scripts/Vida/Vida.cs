using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [Header ("Health")]
   [SerializeField] private float VidaInicial;
    public float VidaAtual { get; private set; }
    private Animator anim;
    public bool dead;

    [SerializeField] private Behaviour[] components;
    private float horizontalInput;
    private Rigidbody2D corpo;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberFlashes;
    private SpriteRenderer spriteRend;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private AudioClip DeadSound;
    private Movimento mov;

    public void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (dead==true)
        {
            horizontalInput = 0;
        }
    }

    private void Awake()
    {
        mov = GetComponent<Movimento>();
        corpo = GetComponent<Rigidbody2D>();
        VidaAtual = VidaInicial;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        //Atribui à variável VidaAtual o valor de VidaInicial, anim de Animator e spriteRend de SpriteRenderer
    }
    public void LevarDano(float _damage)
    {
        VidaAtual = Mathf.Clamp(VidaAtual - _damage, 0, VidaInicial);
        
        if (VidaAtual > 0 )
        {
            if(dead == false)
            {
                AudioManager2.instance.PlaySound(HitSound);
                anim.SetTrigger("Hurt");
                StartCoroutine(Invunerability());
            }
            //Verifica se a vida atual é maior do que 0 e a variável dead for falsa, então toca o som de levar dano, faz a animação de levar dano e chama a função Invunerability
        }
        else
        {
            anim.SetTrigger("Die");
            AudioManager2.instance.PlaySound(DeadSound);

            foreach (Behaviour component in components)
                component.enabled = false;

            if (!dead)
            {
                mov.Dead();

                corpo.constraints = RigidbodyConstraints2D.FreezePositionX;


                GetComponent<Movimento>().enabled = false;
                StartCoroutine(Respawn());
                dead = true;  
            }
            
        }
        //Se a vida atual é menor ou igual a zero então toca o som de morrer, chama a função Respawn, faz a animação de morrer, desablita os scripts do array Behaviour e torna a variáel dead verdadeira
    }

    private IEnumerator Respawn()
    {
        GetComponent<Movimento>().enabled = false;
        yield return new WaitForSeconds(1);
        FindObjectOfType<LeveLManager>().Restart();
        //Chama a função Restart do script LeveLManager
    }

    public void AddHealth(float _value)
    {
        VidaAtual = Mathf.Clamp(VidaAtual + _value, 0, VidaInicial);
        //Adiciona vida ao jogador
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberFlashes;  i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/ (numberFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
    //Faz os frames de invisiblidade onde ocorre a troca de cores e ignora a colisão entre os layers 10 e 11 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fall")
        {
            FindObjectOfType<LeveLManager>().Restart();
            VidaAtual = 0;
            anim.SetTrigger("Die");
            GetComponent<Movimento>().enabled = false;
            dead = true;
        }
        if (collision.tag == "Chase")
        {
            StartCoroutine(Respawn());
            VidaAtual = 0;
            anim.SetTrigger("Die");
            GetComponent<Movimento>().enabled = false;
            dead = true;
        }
        // Mata o jogador se colidir com os objectos com as tags Chase e Fall

    }
}
