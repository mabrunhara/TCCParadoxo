using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    public GameObject npcPrefab;  // Prefab do NPC que será spawnado.
    public Transform[] spawnPoints;  // Array de pontos de spawn.

    private bool hasSpawned = false;  // Variável para controlar se o NPC já foi spawnado.

    void Start()
    {
        if (!hasSpawned)
        {
            Spawn();
            hasSpawned = true;
        }
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Não há pontos de spawn definidos!");
            return;
        }

        // Escolhe aleatoriamente um índice na matriz de spawnPoints.
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Obtém a posição do ponto de spawn selecionado.
        Vector3 spawnPosition = spawnPoints[randomIndex].position;

        // Faz o spawn do NPC na posição determinada.
        Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
    }
}
