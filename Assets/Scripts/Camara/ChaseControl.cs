using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChaseControl : MonoBehaviour
{
    public FenmyAI[] enemyArray;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach (FenmyAI enemy in enemyArray)
            {
                enemy.chase = true;
            }
        }
        //  Verifica se colide com alguem com a tag Player e se colidiu faz com que a variável chase de todos os elementos do array FenmyAI seja verdadeira 

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (FenmyAI enemy in enemyArray)
            {
                enemy.chase = false;
            }
        }
    }
    // Quando para de colidir com alguem com a tag Player faz com que a variável chase de todos os elementos do array FenmyAI seja falsa 
}
