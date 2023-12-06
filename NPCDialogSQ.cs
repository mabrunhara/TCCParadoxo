using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class NPCDialogSQ : MonoBehaviour
{
    public int npcIndex;  // �ndice �nico para identificar cada NPC
    public KeyCode interactKey = KeyCode.E;
    public Canvas dialogCanvas;
    public Text dialogText;

    private bool playerInRange = false;
    private int currentDialogueIndex = 0;  // �ndice atual do di�logo

    void Start()
    {
        dialogCanvas.enabled = false;
    }

    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                StartDialog();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            dialogCanvas.enabled = true;
            dialogText.text = "Aperte a tecla " + interactKey + " para interagir.";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogCanvas.enabled = false;
            // Remova a linha Destroy(gameObject) para evitar destruir o objeto NPC
            currentDialogueIndex = 0;  // Reinicia o �ndice quando o jogador sai da �rea
        }
    }

    void StartDialog()
    {
        // Chama o DialogueManager para iniciar o di�logo com base no �ndice do NPC e �ndice do di�logo
        DialogueManagerSQ.Instance.StartDialogue(npcIndex, currentDialogueIndex);

        // Incrementa o �ndice para a pr�xima intera��o
        currentDialogueIndex++;

        // Verifica se atingiu o final dos di�logos e reinicia se necess�rio
        if (currentDialogueIndex >= DialogueManagerSQ.Instance.GetTotalDialogues(npcIndex))
        {
            currentDialogueIndex = 0;

            // Inicia a quest ao finalizar os di�logos do NPC
            // QuestManager.Instance.StartQuest("Coleta de Itens", "Colete 10 itens no mapa!");
        }
    }
}
