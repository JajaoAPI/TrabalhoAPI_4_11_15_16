using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    private float horizontalInput;
    [SerializeField] private Transform attackpoint;
    public float attackRange = 0.5f;
    [SerializeField] private LayerMask enemy;
    public int attackDamage = 40;
    public float attackRate = 2f;
    public float nextAttactime = 0f;
    private bool attack = false;
    [SerializeField] private AudioClip AttackSound;
    public bool level7;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        // Atribui � vari�vel anim de Animator
    }
    private void Update()
    {
        if(attack == true)
        {
            GetComponent<Movimento>().enabled = false;
        }
        else
        {
            GetComponent<Movimento>().enabled = true;
        }
        //Se attack for verdadeiro enta�o o jogador n�o se pode mover
        horizontalInput = Input.GetAxis("Horizontal");
        if(Time.time >= nextAttactime)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                attack = true;
                Attack();
                nextAttactime = Time.time + 1f / attackRate;
        }
        //Chama a fun��o atacar, mete a vari�vel attack verdadeira e calcula o pr�ximo tempo de ataque ao clicar no bot�o esquerdo do rato
    }
    private void Attack()
    {
        AudioManager2.instance.PlaySound(AttackSound);
        if (horizontalInput == 0f)
        {
            anim.SetTrigger("Attack");
            
        }  
        else
        {
            anim.SetTrigger("AttackR");
            
        }
        // Toca o som de attack e dependendo do movimento faz anima��es diferentes de ataque
        attack = false;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position,attackRange,enemy);
        if(level7 ==true)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Bosshealth>().TakeDamage(attackDamage);

            }
        }
        else
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<VidaEnemy>().TakeDamage(attackDamage);
            }
        }
        
        //Numa area de ataque verifica todos os inimigos que est�o nela dando dano
    }
    private void OnDrawGizmosSelected()
        
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

    //Representa��o da area de ataque no unity
}
