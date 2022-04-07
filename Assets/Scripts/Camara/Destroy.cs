using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chase"))
        {
            Destroy(gameObject);
        }
        //   //  Verifica se colide com alguem com a tag Chase e se colidiu faz com que o prórprio objecto se destrua
    }

}
