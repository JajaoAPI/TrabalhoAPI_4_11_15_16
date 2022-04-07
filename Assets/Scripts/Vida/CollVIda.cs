using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollVIda : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Vida>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
    // Ao colidir com um objeto com a tag Player aumenta a vida do jogador e desativa-se
}
