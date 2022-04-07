using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private Rigidbody2D a;
    private Vida playerHealth;
    [SerializeField] private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.LevarDano(damage);
        }
        //Deteta se o objecto colidiu com o jogador, e se colidiu da dano

    }
}

