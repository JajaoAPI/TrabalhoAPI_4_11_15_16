using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void JogarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Passa a Scene atual para a próxima Scene no buildIndex
    }
    public void SairJogo()
    {
        Debug.Log("QUIT");
        Application.Quit();
        // Fecha a aplicação, como o jogo está no unity apenas faz com que apareça no debug: QUIT
    }
}
