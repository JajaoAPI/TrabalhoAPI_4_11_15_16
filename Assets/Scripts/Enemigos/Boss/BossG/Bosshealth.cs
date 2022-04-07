using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosshealth : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] private Behaviour[] components;
    [SerializeField] private Animator anim;
    public int maxHealth2 = 120;
    private int currentHealth;

    private BossPatrol P;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;

    public GameObject plataforma;
    public GameObject plataforma2;
    public GameObject plataforma3;
    public GameObject plataforma4;
     

    [SerializeField] private AudioClip DeadSound;
    [SerializeField] private AudioClip HitSound;


    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth2;
        P = GetComponentInParent<BossPatrol>();

        //  Atribui as variáveis anim o valor de Animator, currentHealth de maxHealth2 e P de BossPatrol
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        if (currentHealth <= 0)
        {
            AudioManager2.instance.PlaySound(DeadSound);
            foreach (Behaviour component in components)
                component.enabled = false;
            anim.SetTrigger("die");
            StartCoroutine(Respawn());
        }
        else
        {
            AudioManager2.instance.PlaySound(HitSound);
            FindObjectOfType<BossPatrol>().Directionc();
            anim.SetTrigger("hit");
        }

        if (currentHealth <= 80 && currentHealth > 0)
        {
            Destroy(plataforma);
            Destroy(plataforma2);
            Destroy(plataforma3);
            Destroy(plataforma4);
            anim.SetTrigger("Rage");
        }
        // Verifica se a vida do inimigo é menor ou igual a zero, se toca o som de morrer, desablita os scrpits presentes no array Behaviour, faz a animação de morrer e chama a funçao Respawn
        // Se a vida for maior do que zero toca o som de levar hit e toca a animação de levar hit
        // Se a vida for 80 ou menor faz a animação de rage e destroi as plataformas

    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);

        if (gameObject != null)
            Destroy(gameObject);
        Time.timeScale = 0f;
        Menu.SetActive(true);

        // Espera 2 segundos e destroy o objecto

    }


}
