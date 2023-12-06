using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class NPCDialog_FF : MonoBehaviour
{
    public int npcIndex;  // �ndice �nico para identificar cada NPC
    public KeyCode interactKey = KeyCode.E;
    public Canvas dialogCanvas;
    public Text dialogText;
    GameObject cutsceneFim;
    private bool playerInRange = false;
    private int currentDialogueIndex = 0;  // �ndice atual do di�logo

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
            currentDialogueIndex = 0;  // Reinicia o �ndice quando o jogador sai da �rea
        }
    }

    void StartDialog()
    {
        // Chama o DialogueManager para iniciar o di�logo com base no �ndice do NPC e �ndice do di�logo
        DialogueManager_FF.Instance.StartDialogue(npcIndex, currentDialogueIndex);

        // Incrementa o �ndice para a pr�xima intera��o
        currentDialogueIndex++;

        // Verifica se atingiu o final dos di�logos e reinicia se necess�rio
        if (currentDialogueIndex >= DialogueManager_FF.Instance.GetTotalDialogues(npcIndex))
        {
           

        }

        if (currentDialogueIndex >= 7)
        {
            cutsceneFim.SetActive(true);
        }

    }
}
