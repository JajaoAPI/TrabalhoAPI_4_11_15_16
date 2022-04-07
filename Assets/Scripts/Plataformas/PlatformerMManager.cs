using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMManager : MonoBehaviour
{
    public static PlatformerMManager instance = null;
    [SerializeField] GameObject platformPrefab;
    public bool leve52;
    public bool Level6;

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
        if (leve52 == true)
        {
            Instantiate(platformPrefab, new Vector2(-0.195406f, 38.28327f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(-3.495406f, 36.83327f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(3.174594f, 39.93327f), platformPrefab.transform.rotation);
            
        }
        else if (Level6 ==true)
        {
            Instantiate(platformPrefab, new Vector2(40.2081f, -2.918886f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(43.17f, -2.918886f), platformPrefab.transform.rotation);
            Instantiate(platformPrefab, new Vector2(46.73f, -2.918886f), platformPrefab.transform.rotation);
        }
        //  Cria plataformas em diferentes locais dependendo da variável verdadeira 
    }

    public IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
    // Dá spawn as platafromas criadas na posição das antigas
}
