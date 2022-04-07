using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject WallPrefab;
    public GameObject Spawner;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Boss"))
        {
            WallPrefab.SetActive(true);
        }
        //  Verifica se colide com alguem com a tag Boss e se colidiu faz com que o objecto WallPrefab seja ativo

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            WallPrefab.SetActive(false);
        }
    }
    // O objecto com a tag Boss ao sair parar decolidir com o objecto faz com que o objecto WallPrefab seja desativado
}
