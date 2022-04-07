using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseMenu;

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        // Verifica se a tecla p foi presionada, se foi verfica se a vari�vel isGamePaused � verdadeira, se � chama a fun��o ResumeGame, se n�o chama a fun��o PauseGame
    }
    public void ResumeGame()
    {
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        // Retoma o audio, atribui um valor de falso a vari�vel isGamePaused, desativa o menu de pausa e resume o jogo
    }
    public void PauseGame()
    {
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        // Para o audio, atribui um valor de Verdadeiro a vari�vel isGamePaused, ativa o menu de pausa e para o jogo
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
        // Volta a carregar a primeira Scene
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
        // Feacha a aplica��o, como est� no unity apenas apare�e no DebugLog: Quit
    }
}
