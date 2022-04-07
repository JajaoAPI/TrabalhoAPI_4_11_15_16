using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossF : MonoBehaviour
{
    public float speed2;
    private GameObject player;
    public bool chase = false;
    [SerializeField] private Transform startingPoint;
    private Animator anim;
    private Vida playerHealth;
    [SerializeField] private int damage;


    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        //Atribui o a variável player o valor do jogador e a variável anim o valor de Animator 
    }


    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (chase == true)
        {
            Chase();
        }
        else
        {
            ReturnStatPoint();
        }
    }
    //Verifica se chase é verdadeiro, se for chama a função Chase, se não chama a função ReturnStatPoint

    private void ReturnStatPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed2 * Time.deltaTime);
        //Faz com que o inimigo volte para a posição inicial 
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed2 * Time.deltaTime);
        //Faz com que o inimigo presiga o jogador
    }






}
