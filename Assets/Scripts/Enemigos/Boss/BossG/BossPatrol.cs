using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private Bosshealth HEALTH;
    public int maxHealth2 = 120;
    private int currentHealth;
    [SerializeField] private AudioClip AttackSound;

    private void Start()
    {
        currentHealth = maxHealth2;
        HEALTH = GetComponent<Bosshealth>();
        //  Atribui as vari�veis currentHealth o valor de maxHealth2 e HEALTH de Bosshealth 
    }
    private void Awake()
    {
        initScale = enemy.localScale;
        //Atribui o a vari�vel initScale o valor do scale do inimigo
    }
    private void OnDisable()
    {
        anim.SetBool("moving", false);
        //Atribui a variavel de anima��o moving um valor de falso
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }

        //Verifica se o inimigo est� a andar para a esquerda, se tiver andar para a equerda vai verificar se a sua posi��o � maior ou igual � posi��o do leftEdge, se for move-se at� o ponto, se n�o troca a dire��o
        //Se n�o estiver a andar para a esquerda verifica se a sua posi��o � menor ou igual � posi��o do rightEdge e se for move-se at� l�, se n�o troca de dire��o


    }

    public void Directionc()
    {
        movingLeft = !movingLeft;
        //Troca a dire��o
    }

    private void DirectionChange()
    {
       
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
        //Atribui a variavel de anima��o moving um valor de falso, come�a o idleTimer e inverte a dire��o
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);
        //Atribui a variavel de anima��o moving um valor de verdadeiro

        
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);
        //Faz com que o inimigo olhe para a sentido correto 

       
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
        //Faz com que o inimigo ande nessa dire��o
    }


}
