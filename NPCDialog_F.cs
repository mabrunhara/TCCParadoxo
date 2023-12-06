using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class NPCDialog_F : MonoBehaviour
{
    public int npcIndex;  // �ndice �nico para identificar cada NPC
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
    // �ndice atual do di�logo

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
            currentDialogueIndex = 0;  // Reinicia o �ndice quando o jogador sai da �rea
        }
    }

    void StartDialog()
    {
        // Chama o DialogueManager para iniciar o di�logo com base no �ndice do NPC e �ndice do di�logo
        DialogueManager_F.Instance.StartDialogue(npcIndex, currentDialogueIndex);

        // Incrementa o �ndice para a pr�xima intera��o
        currentDialogueIndex++;

        // Verifica se atingiu o final dos di�logos e reinicia se necess�rio
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
