using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movimento : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float PoderSalto;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D corpo;
    private Animator anim;
    private BoxCollider2D boxColider;
    private float wallJumpCooldown;
    private float horizontalInput;
    public GameObject Player;
    [SerializeField] private AudioClip JumpSound;
    public bool dead;
    



    private void Awake()
    {
        corpo = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxColider = GetComponent<BoxCollider2D>();
        // Atribui à variável corpo o valor de Rigidbody2D, anim de Animator e boxColider de BoxCollider2D

    }
    public void Update()
    {
        if(dead == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        // Permite o movimento horizontal

        if (corpo.velocity.y < 0 && !IsGrounded())
        {
            anim.SetTrigger("Fall");
        }
        else if((corpo.velocity.y >= 0 && !IsGrounded()))
        {
            
            anim.SetTrigger("Saltar");
        }
        // Faz as animações de Saltar e Cair 

        if (horizontalInput > 0.01f)
             transform.localScale = new Vector3(3,3,1);

             else if (horizontalInput < -0.01f)
             transform.localScale = new Vector3(-3, 3, 1);
        // faz com que ao andar para o lado a personagem vira-se

        anim.SetBool("Correr", horizontalInput !=0);
        anim.SetBool("Grounded", IsGrounded());

        if (wallJumpCooldown > 0.2f)
        {
            corpo.velocity = new Vector2(horizontalInput * velocidade, corpo.velocity.y);

            
            if (OnWall() && !IsGrounded())
            {
                corpo.gravityScale = 0;
                corpo.velocity = Vector2.zero;
                
            }
            
            else 
                corpo.gravityScale = 3;
            // Se estiver numa parede e não estiver no chão então fica agarrado à parede, se não ganha força gravitica

            if (Input.GetKey(KeyCode.Space))
            {
                Saltar();


                if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                {
                    AudioManager2.instance.PlaySound(JumpSound);
                }
            }
            // Se clicar no espaço chama a função Saltar e toca o som de salto
        }
        else wallJumpCooldown += Time.deltaTime;
        // Aumenta o wallJumpCooldown
    }
    private void Saltar()
    {
        

        if (IsGrounded())
        {
            corpo.velocity = new Vector2(corpo.velocity.x, PoderSalto);
            anim.SetTrigger("Saltar");
            // Faz a animação de saltar e salta
        }
        else if(OnWall() && !IsGrounded())
        {
            AudioManager2.instance.PlaySound(JumpSound);
            if (horizontalInput == 0)
            {
                
                corpo.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                
            }
            else
                corpo.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            
              
            
              
            wallJumpCooldown = 0;
          
        }
    }
    // Permite o wallJump e dá reset no walljumpCooldown
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, boxColider.bounds.size,0,Vector2.down,0.1f, groundLayer);
        return raycastHit.collider !=null;
        // Com raycas verifica se está a colidir com um objecto do groundLayer

    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, boxColider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
        // Com raycas verifica se está a colidir com um objecto do wallLayer
    }


    public void Dead()
    {
       
       
            dead = true;
        // Mete a variável dead Verdadeira
    }

}







