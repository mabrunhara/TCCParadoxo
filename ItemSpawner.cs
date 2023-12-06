using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
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
        // Gera uma posi��o aleat�ria para o item
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));

        // Instancia o prefab do item na posi��o gerada
        GameObject collectableItem = Instantiate(collectableItemPrefab, spawnPosition, Quaternion.identity);

        // olha se que o item tem o script CollectableItem anexado
        CollectableItem collectableItemScript = collectableItem.GetComponent<CollectableItem>();
        if (collectableItemScript == null)
        {
            Debug.LogWarning("O prefab do item colecion�vel n�o tem o script CollectableItem anexado. Adicione o script para permitir a coleta.");
        }
    }
}
