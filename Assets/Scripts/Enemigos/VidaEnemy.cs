using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private Behaviour[] components;
    [SerializeField] private Animator anim;
    public int maxHealth = 100;
    private int currentHealth;
      public GameObject drop;
    private Rigidbody2D rb;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private AudioClip DeadSound;
    public bool dead;
    public bool F;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        //  Atribui as variáveis anim o valor de Animator, currentHealth de maxHealth e rb de Rigidbody2D
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <=0)
        {
            if(dead==false)
            {
                if(F == true)
                {
                    rb.gravityScale = 10;
                }
                
                Physics2D.IgnoreLayerCollision(10, 11, true);
                drop.SetActive(true);
                AudioManager2.instance.PlaySound(DeadSound);
                dead = true;
                foreach (Behaviour component in components)
                    component.enabled = false;
                anim.SetTrigger("die");
                StartCoroutine(Respawn());
            }
           
        }
        else
        {
            if(dead == false)
            {
                AudioManager2.instance.PlaySound(HitSound);
                anim.SetTrigger("hit");
            }
            
        }
        // Verifica se a vida do inimigo é menor ou igual a zero, se toca o som de morrer, desablita os scrpits presentes no array Behaviour, faz a animação de morrer e chama a funçao Respawn
        // Se a vida for maior do que zero toca o som de levar hit e toca a animação de levar hit

    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        
        if (gameObject !=null)
        Destroy(gameObject);
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Instantiate(drop, transform.position, Quaternion.identity);
         
        // Espera 2 segundos e destroy o objecto
    }


}
