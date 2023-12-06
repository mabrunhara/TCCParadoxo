using UnityEngine;

public class SpawnerPortal : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject portalPrefab;
    GameObject portal;
    GameObject quests;
    QuestManager complete;
    public string questName; // Nome da quest a ser verificada

    void Start()
    {
        portal = GameObject.Find("PrefabPortal");
        quests = GameObject.Find("Quest");
        complete = quests.GetComponent<QuestManager>();
        portal.SetActive(false);
        // Verifica se a quest foi concluída antes de chamar SpawnPortal
        if (QuestManager.Instance.IsQuestCompleted(questName))
        {
            portal.SetActive(true);
        }
        else
        {
            Debug.Log("Quest não concluída. Portal não será spawnado.");
        }
    }
    void Update()
    {
        if (complete.collectedItemCount == 5)
        {
            portal.SetActive(true);
        }
    }

    void SpawnPortal()
    {
        // Verifique se o prefab do portal está atribuído
        if (portalPrefab == null)
        {
            Debug.LogError("Prefab do portal não atribuído no SpawnerPortal.");
            return;
        }

        // Instancie o portal no ponto de spawn
        GameObject portal = Instantiate(portalPrefab, spawnPoint.position, spawnPoint.rotation);

        // Configure o spawnPoint no PortalScript
        PortalScript portalScript = portal.GetComponent<PortalScript>();
        if (portalScript != null)
        {
            portalScript.SetSpawnPoint(spawnPoint);
        }
        else
        {
            Debug.LogError("PortalScript não encontrado no portal.");
        }
    }
}
