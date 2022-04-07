using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool P = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Atribui à variável rb o valor de Rigidbody2D 
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(P==true)
            {
                PlatformerMManager.instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));
                Invoke("DropPlatform", 0.5f);
                Destroy(gameObject, 2f);
            }
            // Ao colidir com um objeto com a tag Player e se P for verdadeiro, chama a função SpawnPlatform e DropPlatform e destroy o gameobject
        }
    }
    private void DropPlatform()
    {
        rb.isKinematic = false;
        P = false;
        //Faz com que Kinematic e p sejam falsos
    }
}
