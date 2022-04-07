using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] private Vida VidaJogagor;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = VidaJogagor.VidaAtual / 10;
        //Atribui a vida inicial do jogador a barra de vida 
    }

    private void Update()
    {
        currentHealthBar.fillAmount = VidaJogagor.VidaAtual / 10;
        // Dá update ao fill da barra de vida dependendo da vida do jogador
    }
}
