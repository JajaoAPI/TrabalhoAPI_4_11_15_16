using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meelenemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private AudioClip AttackSound;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;


    //References
    private Animator anim;
    private Vida playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        //  Atribui as variáveis anim o valor de Animator e enemyPatrol o valor de EnemyPatrol 
    }

        private void Update()
        {
            cooldownTimer += Time.deltaTime;
            // Soma o tempo que passa ao cooldownTimer



            if (PlayerInSight())
            {
                if (cooldownTimer >= attackCooldown)
                {
                    AudioManager2.instance.PlaySound(AttackSound);
                    cooldownTimer = 0;
                    anim.SetTrigger("meleeAttack");

                }
            }
            // Se o jogador estiver no range do inimigo e o cooldown de ataque for menor ou igual ao cooldown Timer, o inimigo ataca, toca o som de ataque, da reset no cooldownTimer e faz a animação de ataque

            if (enemyPatrol != null)
                enemyPatrol.enabled = !PlayerInSight();
            //Faz com que se o inimigo estiever em patrol então o jogador não está no range do inimigo

        }

        private bool PlayerInSight()
        {
            RaycastHit2D hit =
                Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
                0, Vector2.left, 0, playerLayer);

            if (hit.collider != null)
                playerHealth = hit.transform.GetComponent<Vida>();

            return hit.collider != null;

            //Cria a area de ataque do inimigo com centro no inimgio e que deteta os elementos do Player array
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
            //Cria uma replica da area de ataque do inimigo no unity
        }

        private void DamagePlayer()
        {
            if (PlayerInSight())
                playerHealth.LevarDano(damage);
            //Da dano ao jogador se ele levar com o ataque
        }
    
}
