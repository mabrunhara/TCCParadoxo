using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class NPCDialog_T : MonoBehaviour
{
    public int npcIndex;  // �ndice �nico para identificar cada NPC
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
    private int currentDialogueIndex = 0;  // �ndice atual do di�logo

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
            currentDialogueIndex = 0;  // Reinicia o �ndice quando o jogador sai da �rea
        }
    }

    void StartDialog()
    {
        // Chama o DialogueManager para iniciar o di�logo com base no �ndice do NPC e �ndice do di�logo
        DialogueManager_T.Instance.StartDialogue(npcIndex, currentDialogueIndex);

        // Incrementa o �ndice para a pr�xima intera��o
        currentDialogueIndex++;

        // Verifica se atingiu o final dos di�logos e reinicia se necess�rio
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
