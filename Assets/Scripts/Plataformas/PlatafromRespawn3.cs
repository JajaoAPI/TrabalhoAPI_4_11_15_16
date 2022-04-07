using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatafromRespawn3 : MonoBehaviour
{
    public static PlatafromRespawn3 instance = null;
    [SerializeField] GameObject platformPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(platformPrefab);
        // Verifica se existe alguma plataforma e destroi se existir 

    }

    private void Start()
    {
        Instantiate(platformPrefab, new Vector2(52f,-8.4f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(57.7f,-5.9f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(62.5f,-2.9f), platformPrefab.transform.rotation);
        //  Cria plataformas em diferentes locais dependendo da variável verdadeira 

    }
    public IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
        // Dá spawn as platafromas criadas na posição das antigas
    }
}
