using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class NPCDialog : MonoBehaviour
{
    public int npcIndex;  // Índice único para identificar cada NPC
    public KeyCode interactKey = KeyCode.E;
    public Canvas dialogCanvas;
    public Text dialogText;

    private bool playerInRange = false;
    private int currentDialogueIndex = 0;  // Índice atual do diálogo

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
            currentDialogueIndex = 0;  // Reinicia o índice quando o jogador sai da área
        }
    }

    void StartDialog()
    {
        // Chama o DialogueManager para iniciar o diálogo com base no índice do NPC e índice do diálogo
        DialogueManager.Instance.StartDialogue(npcIndex, currentDialogueIndex);

        // Incrementa o índice para a próxima interação
        currentDialogueIndex++;

        // Verifica se atingiu o final dos diálogos e reinicia se necessário
        if (currentDialogueIndex >= DialogueManager.Instance.GetTotalDialogues(npcIndex))
        {
            currentDialogueIndex = 0;

            // Inicia a quest ao finalizar os diálogos do NPC
            QuestManager.Instance.StartQuest("Coleta de Itens", "Colete 5 itens no mapa!");

        }

    }
}
