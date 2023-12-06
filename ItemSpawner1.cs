using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawner1 : MonoBehaviour
{
    public GameObject collectableItemPrefab;
    public int numberOfItemsToSpawn = 10;


    public void SpawnItems()
    {
        // ver se o colet�vel est� atribu�do no Inspector
        if (collectableItemPrefab == null)
        {
            Debug.LogError("Prefab do item colecion�vel n�o atribu�do ao ItemSpawner.");
            return;
        }

        // Instancia os itens colecion�veis no n�mero especificado
        for (int i = 0; i < numberOfItemsToSpawn; i++)
        {
            SpawnCollectableItem();
        }
    }

    void SpawnCollectableItem()
    {
        if (SceneManager.GetActiveScene().name == "Floresta") 
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-15f, 20f), 1.6f, Random.Range(12f, 37f));
            GameObject collectableItem = Instantiate(collectableItemPrefab, spawnPosition, Quaternion.identity);

            CollectableItem collectableItemScript = collectableItem.GetComponent<CollectableItem>();
            if (collectableItemScript == null)
            {
                Debug.LogWarning("O prefab do item colecion�vel n�o tem o script CollectableItem anexado. Adicione o script para permitir a coleta.");
            }
        }

        if (SceneManager.GetActiveScene().name == "Codigos")
        {
            // Gera uma posi��o aleat�ria para o item
            Vector3 spawnPosition = new Vector3(Random.Range(19f, 101f), 11f, Random.Range(-79f, -40f));
            GameObject collectableItem = Instantiate(collectableItemPrefab, spawnPosition, Quaternion.identity);

            CollectableItem collectableItemScript = collectableItem.GetComponent<CollectableItem>();
            if (collectableItemScript == null)
            {
                Debug.LogWarning("O prefab do item colecion�vel n�o tem o script CollectableItem anexado. Adicione o script para permitir a coleta.");
            }
        }

        // Instancia o prefab do item na posi��o gerada
       

        // olha se que o item tem o script CollectableItem anexado
       
    }
}
