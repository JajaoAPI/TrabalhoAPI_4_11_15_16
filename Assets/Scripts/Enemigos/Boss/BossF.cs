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
        //Atribui o a vari�vel player o valor do jogador e a vari�vel anim o valor de Animator 
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
    //Verifica se chase � verdadeiro, se for chama a fun��o Chase, se n�o chama a fun��o ReturnStatPoint

    private void ReturnStatPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed2 * Time.deltaTime);
        //Faz com que o inimigo volte para a posi��o inicial 
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed2 * Time.deltaTime);
        //Faz com que o inimigo presiga o jogador
    }






}
