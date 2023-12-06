using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class NPCDialog_F : MonoBehaviour
{
    public int npcIndex;  // Índice único para identificar cada NPC
    public KeyCode interactKey = KeyCode.E;
    public Canvas dialogCanvas;
    public Text dialogText;
    GameObject boss;
    GameObject dialo;
    GameObject final;
    scriptFinal finalmentes;
    private bool playerInRange = false;
    private int currentDialogueIndex = 0;
    private float waitForDia = 2f;
    // Índice atual do diálogo

    void Start()
    {
        final = GameObject.Find("cirujafinal");
        finalmentes = final.GetComponent<scriptFinal>();
        dialo = GameObject.Find("CanvasDialo");
        boss = GameObject.Find("CirujaPrefab");
        dialogCanvas.enabled = false;
        boss.SetActive(false);
       
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
        DialogueManager_F.Instance.StartDialogue(npcIndex, currentDialogueIndex);

        // Incrementa o índice para a próxima interação
        currentDialogueIndex++;

        // Verifica se atingiu o final dos diálogos e reinicia se necessário
        if (currentDialogueIndex >= DialogueManager_F.Instance.GetTotalDialogues(npcIndex))
        {
           

        }

        if(currentDialogueIndex >= 5)
        {
            
            boss.SetActive(true);
            Destroy(gameObject);
            Destroy(dialo);
        }

    }
}
