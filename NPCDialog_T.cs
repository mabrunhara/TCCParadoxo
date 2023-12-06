using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class NPCDialog_T : MonoBehaviour
{
    public int npcIndex;  // Índice único para identificar cada NPC
    public KeyCode interactKey = KeyCode.E;
    public Canvas dialogCanvas;
    public Text dialogText;
    GameObject telaPreta;
    GameObject comandos;
    GameObject cajado;
    GameObject jogado;
    GameObject corujao;
    GameObject tutorialcoi;
    tutorialScript tutorialS;
    PlayerController progra;
    private bool playerInRange = false;
    private int currentDialogueIndex = 0;  // Índice atual do diálogo

    void Start()
    {
        tutorialcoi = GameObject.Find("TutorialCoisas");
        tutorialS = tutorialcoi.GetComponent<tutorialScript>();
        corujao = GameObject.Find("CirujaTutor");
        jogado = GameObject.Find("Player");
        progra = jogado.GetComponent<PlayerController>();
        cajado = GameObject.Find("Cajado");
        comandos = GameObject.Find("Aulas");
        telaPreta = GameObject.Find("telapreta");
        dialogCanvas.enabled = false;
        comandos.SetActive(false);
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
        DialogueManager_T.Instance.StartDialogue(npcIndex, currentDialogueIndex);

        // Incrementa o índice para a próxima interação
        currentDialogueIndex++;

        // Verifica se atingiu o final dos diálogos e reinicia se necessário
        if (currentDialogueIndex >= DialogueManager_T.Instance.GetTotalDialogues(npcIndex))
        {
            Destroy(corujao);

            

        }

        if(currentDialogueIndex >= 8)
        {
            telaPreta.SetActive(false);
        }

        if(currentDialogueIndex >= 46)
        {
            cajado.SetActive(true);
        }

        if(currentDialogueIndex >= 52)
        {
            progra.podeAndar = true;
        }
        if(currentDialogueIndex >= 54)
        {
            comandos.SetActive(true);
        }
       

    }
}
