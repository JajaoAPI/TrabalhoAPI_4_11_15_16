using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhath : MonoBehaviour
{
    [SerializeField] private AudioClip ChaseSound;
    [SerializeField] private AudioClip Normal;
    public BossF[] enemyArray;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager2.instance.PlaySound(ChaseSound);
            foreach (BossF enemy in enemyArray)
            {

                enemy.chase = true;
            }
        }
        //  Verifica se colide com alguem com a tag Player e se colidiu faz com que a variável chase de todos os elementos do array BooF seja verdadeira
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            
            foreach (BossF enemy in enemyArray)
            {
                enemy.chase = false;
            }
        }
    }
    // Quando para de colidir com alguem com a tag Player faz com que a variável chase de todos os elementos do array BossF seja falsa 
}
