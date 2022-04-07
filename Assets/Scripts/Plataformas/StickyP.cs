using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyP : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
           
        }
        // Ao colidir com o jogador,o mesmo torna-se filho da plataforma
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
        
    }
    // Quando o jogador parar de colidir com a plataforma o mesmo para de ser filho da plataforma
}
