using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public Canvas questCanvas;
    public Text questNameText;
    public Text questDescriptionText;
    public Text questProgressText;
    public ItemSpawner1 itemSpawner;
    GameObject perkScreen;
    private string questName;
    private string questDescription;
    private int requiredItemCount = 5;
    public int collectedItemCount = 0;

    public GameObject spawnOnQuestComplete;
    private Vector3 spawnOnQuestCompletePosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        perkScreen = GameObject.Find("PerkScreen");
        questCanvas.enabled = false;
        perkScreen.SetActive(false);
    }

    public void StartQuest(string name, string description)
    {
        questName = name;
        questDescription = description;
        collectedItemCount = 0;

        // Ativa o ItemSpawner para spawnar os itens quando a quest é iniciada
        if (itemSpawner != null)
        {
            itemSpawner.SpawnItems();
        }

        UpdateQuestUI();
        questCanvas.enabled = true;
    }

    public void CollectItem()
    {
        collectedItemCount++;

        if (collectedItemCount >= requiredItemCount)
        {
            CompleteQuest();
        }

        UpdateQuestUI();
    }

    public bool IsQuestCompleted(string questToCheck)
    {
        return questToCheck.Equals(questName) && collectedItemCount >= requiredItemCount;
    }

    private void CompleteQuest()
    {
        Debug.Log("Quest completed!");
       
       // Desativa o canvas da quest quando o player termina ela
        questCanvas.enabled = false;
        perkScreen.SetActive(true);

        if (spawnOnQuestComplete != null)
        {
            Instantiate(spawnOnQuestComplete, transform.position, Quaternion.identity);
        }
    }

    public void SetSpawnPosition(Vector3 position)
    {
        spawnOnQuestCompletePosition = position;
    }

    private void UpdateQuestUI()
    {
        questNameText.text = "Quest:  " + questName;
        questDescriptionText.text = "Description: " + questDescription;
        questProgressText.text = "Progresso: " + collectedItemCount + "/" + requiredItemCount;
    }
}
