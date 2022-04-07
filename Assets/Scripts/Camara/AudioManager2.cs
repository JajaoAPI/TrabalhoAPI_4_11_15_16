using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public static AudioManager2 instance { get; private set; }
    private AudioSource sorce;

    private void Awake()
    {
        instance = this;
        sorce = GetComponent<AudioSource>();
        // Atribui o valor da variável instance a class AudioManager2 e a variavel sorce o component AudioSource
    }
    public void PlaySound(AudioClip _sound)
    {
        sorce.PlayOneShot(_sound);
        // Toca uma vez o clip de audio 
    }
}
