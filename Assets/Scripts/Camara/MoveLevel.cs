using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    [SerializeField] private string newLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(newLevel);
        }
    }
    //  Verifica se colide com alguem com a tag Player e se colidiu muda de Scene
}
