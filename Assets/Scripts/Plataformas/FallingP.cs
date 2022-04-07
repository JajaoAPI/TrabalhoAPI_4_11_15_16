using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingP : MonoBehaviour
{
    private BoxCollider2D B;
    private Rigidbody2D rb;
    private bool P = true;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        B = GetComponent<BoxCollider2D>();

        // Atribui à variável rb o valor de Rigidbody2D e à variável B o valor de BoxCollider2D
    }

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(6, 6, true);
        // Ignora a colisão entre os elementos do layer 6
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(P==true)
            {
                PlataformManager.instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));
                Invoke("DropPlatform", 0.5f);
                Destroy(gameObject, 2f);
            }

            // Ao colidir com um objeto com a tag Player e se P for verdadeiro, chama a função SpawnPlatform e DropPlatform e destroy o gameobject
        }
    }
    private void OnCollsionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Physics2D.IgnoreLayerCollision(6, 10, true);
            //Ignora a colisão entre os layers 6 e 10
        }
    }
    private void DropPlatform()
    {
        rb.isKinematic = false;
        P = false;
        //Faz com que Kinematic e p sejam falsos
    }


}



