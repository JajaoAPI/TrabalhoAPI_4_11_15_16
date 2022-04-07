using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFVida : MonoBehaviour
{
    [SerializeField] private Behaviour[] components;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioClip DeadSound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //Atribui o a variável rb o valor do Rigidbody2D e a variável anim o valor de Animator 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Killer"))
        {
            AudioManager2.instance.PlaySound(DeadSound);
            foreach (Behaviour component in components)
                component.enabled = false;
            
            anim.SetTrigger("die");
            rb.isKinematic = false;
        }
    }
    //Verifica se o objecto colidiu com um objecto com a tag Killer, se colidiu toca o som de morte, desablitas os scripts do array Behaviour, faz a animação de morrer e torna o valor de kinematic falso
}
