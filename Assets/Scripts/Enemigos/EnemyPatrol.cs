using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
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

    private void Awake()
    {
        initScale = enemy.localScale;
        //Atribui o a variável initScale o valor do scale do inimigo
    }
    private void OnDisable()
    {
        anim.SetBool("moving", false);
        //Atribui a variavel de animação moving um valor de falso
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
        //Verifica se o inimigo está a andar para a esquerda, se tiver andar para a equerda vai verificar se a sua posição é maior ou igual à posição do leftEdge, se for move-se até o ponto, se não troca a direção
        //Se não estiver a andar para a esquerda verifica se a sua posição é menor ou igual à posição do rightEdge e se for move-se até lá, se não troca de direção
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;

        //Atribui a variavel de animação moving um valor de falso, começa o idleTimer e inverte a direção
        
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);
        //Atribui a variavel de animação moving um valor de verdadeiro

       
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);
        //Faz com que o inimigo olhe para a sentido correto 

       
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
        //Faz com que o inimigo ande nessa direção
    }
}
