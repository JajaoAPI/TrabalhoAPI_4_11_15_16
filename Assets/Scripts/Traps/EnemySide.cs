using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySide : MonoBehaviour
{   [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingEsquerda;
    private float LeftEdge;
    private float rightRdge;

    private void Awake()
    {
        LeftEdge = transform.position.x - movementDistance;
        rightRdge = transform.position.x + movementDistance;
        // Determina os extremos de movimento da plataforma
    }
    private void Update()
    {
        if (movingEsquerda)
        {
            if( transform.position.x > LeftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingEsquerda = false;
            }
        }
        else
        {
            if (transform.position.x < rightRdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingEsquerda = true;
            }
            // Verifica se o a armadilha está a mover para a esquerda e a sua posição relativa em relação aos extremos
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Vida>().LevarDano(damage);
        }
        // Ao colidir com o jogador dá-lhe dano
    }
}
