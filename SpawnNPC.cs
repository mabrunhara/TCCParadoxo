using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    public GameObject npcPrefab;  // Prefab do NPC que ser� spawnado.
    public Transform[] spawnPoints;  // Array de pontos de spawn.

    private bool hasSpawned = false;  // Vari�vel para controlar se o NPC j� foi spawnado.

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
            Debug.LogError("N�o h� pontos de spawn definidos!");
            return;
        }

        // Escolhe aleatoriamente um �ndice na matriz de spawnPoints.
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Obt�m a posi��o do ponto de spawn selecionado.
        Vector3 spawnPosition = spawnPoints[randomIndex].position;

        // Faz o spawn do NPC na posi��o determinada.
        Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
    }
}
