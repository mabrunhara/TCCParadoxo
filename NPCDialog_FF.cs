using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class NPCDialog_FF : MonoBehaviour
{
    public int npcIndex;  // Índice único para identificar cada NPC
    public KeyCode interactKey = KeyCode.E;
    public Canvas dialogCanvas;
    public Text dialogText;
    GameObject cutsceneFim;
    private bool playerInRange = false;
    private int currentDialogueIndex = 0;  // Índice atual do diálogo

    void Start()
    {
        cutsceneFim = GameObject.Find("CANVASFINAL");
        dialogCanvas.enabled = false;
        cutsceneFim.SetActive(false);
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
        DialogueManager_FF.Instance.StartDialogue(npcIndex, currentDialogueIndex);

        // Incrementa o índice para a próxima interação
        currentDialogueIndex++;

        // Verifica se atingiu o final dos diálogos e reinicia se necessário
        if (currentDialogueIndex >= DialogueManager_FF.Instance.GetTotalDialogues(npcIndex))
        {
           

        }

        if (currentDialogueIndex >= 7)
        {
            cutsceneFim.SetActive(true);
        }

    }
}
