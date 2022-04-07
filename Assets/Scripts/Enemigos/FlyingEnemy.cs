using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private AudioClip AttackSound2;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    public float speed2;
   private GameObject player;
   public bool chase = false;
   [SerializeField] private Transform startingPoint;
    private Animator anim;
    private Vida playerHealth;
    private Rigidbody2D rb;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // //  Atribui as variáveis anim o valor de Animator e rb o valor de Rigidbody2D 

    }

    
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        // Soma o tempo que passa ao cooldownTimer

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                AudioManager2.instance.PlaySound(AttackSound2);
                cooldownTimer = 0;
                anim.SetTrigger("EFAttack");
            }
        }
        // Se o jogador estiver no range do inimigo e o cooldown de ataque for menor ou igual ao cooldown Timer, o inimigo ataca, toca o som de ataque, da reset no cooldownTimer 

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
