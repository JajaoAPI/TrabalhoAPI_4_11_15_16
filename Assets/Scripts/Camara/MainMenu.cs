using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void JogarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Passa a Scene atual para a pr�xima Scene no buildIndex
    }
    public void SairJogo()
    {
        Debug.Log("QUIT");
        Application.Quit();
        // Fecha a aplica��o, como o jogo est� no unity apenas faz com que apare�a no debug: QUIT
    }
}
