using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

     public Slider volumeSlider;
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
        //Verifica se existem PlayerPrefs, se existirem chama a função Load, se não existirem atriui o valor 1 as PlayerPrefs e chama a função Load
    }

    // Update is called once per frame
    public void VolumeChange()
   {
        AudioListener.volume = volumeSlider.value;
        Save();
        // Atribui o som que o audioListener produz ao valor do slider, e chama a função Save
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        // Atribui o valor do slider as preferencias do jogador
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        // Guarda o valor do slider nas PlayerPrefs

    }
}
