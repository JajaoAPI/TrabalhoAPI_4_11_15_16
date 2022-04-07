using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] private Transform palyer;
    [SerializeField] private float distanciaFrente;
    [SerializeField] private float velocidadeCamara;
    private float olharFrente;
    public bool LevelY;

    private void Update()
    {
        if(LevelY ==false)
        {
            transform.position = new Vector3(palyer.position.x, palyer.position.y, transform.position.z);
            olharFrente = Mathf.Lerp(olharFrente, (distanciaFrente * transform.localScale.x), Time.deltaTime * velocidadeCamara);
            //  Faz com que a camara foque na personagem e que ela vá um pouco mais para a frente ou para trás dependendo do sentido de movimento do jogador
        }
        else
        {
            transform.position = new Vector3(transform.position.x, palyer.position.y, transform.position.z);
            olharFrente = Mathf.Lerp(olharFrente, (distanciaFrente * transform.localScale.y), Time.deltaTime * velocidadeCamara);
            //  Faz com que a camara foque na personagem e que ela vá um pouco mais para a cima ou para baixo dependendo do sentido de movimento do jogador
        }
    }


}
