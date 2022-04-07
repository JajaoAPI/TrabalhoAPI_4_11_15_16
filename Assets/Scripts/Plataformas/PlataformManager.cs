using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformManager : MonoBehaviour
{
    public static PlataformManager instance = null;
    [SerializeField] GameObject platformPrefab;
    public bool Level1;
    public bool Level3;
    public bool Level51;
    public bool leve52;
    public bool level6;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(platformPrefab);
            
        }
        // Verifica se existe alguma plataforma e destroi se existir 

    }

    private void Start()
    {
        if(Level1 == true)
        {
            Instantiate(platformPrefab, new Vector2(39.74f, -3.69f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(44.73f, -3.69f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(49.31f, -3.69f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(53.86f, -3.69f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(57.87f, -3.69f), platformPrefab.transform.rotation);
        }
        else if(Level3 == true)
        {
            Instantiate(platformPrefab, new Vector2(48.11554f, -5.504689f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(52.41554f, -3.904689f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(56.41554f, -2.304689f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(60.61554f, -0.4046888f), platformPrefab.transform.rotation);
           
        }
        
        else if (Level51 == true)
       {
            
            Instantiate(platformPrefab, new Vector2(-2.79f, 29.34f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(-5.67f, 30.43f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(-9.03f, 31.89f), platformPrefab.transform.rotation); 

        }
        
        else if(level6 == true)
        {
            Instantiate(platformPrefab, new Vector2(13.35f, -4.55f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(18.94f, -4.55f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(22.66f, -2.9f), platformPrefab.transform.rotation);
        }
        //  Cria plataformas em diferentes locais dependendo da variável verdadeira 
    }
    public IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);

        // Dá spawn as platafromas criadas na posição das antigas
    }
}
      

