using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class DialogueManager_F : MonoBehaviour
{
    public static DialogueManager_F Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        new string[] {"Ciruja:\r\n Sinto muito pequenino, mas você não entenderia...","Ciruja:\r\n Infelizmente a única forma de retornar a sua casa é passando por mim...", "Ciruja:\r\n E sejamos sensatos, isso nunca irá acontecer...","Ciruja:\r\n Então volte de onde veio ou se prepare para perder.", ""},
        
        // Adicione mais diálogos conforme necessário
    };

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
        dialogCanvas.enabled = false;
    }

    public void StartDialogue(int npcIndex, int dialogueIndex)
    {
        dialogCanvas.enabled = true;
        dialogText.text = "";

        // Adiciona cada linha de diálogo do NPC ao texto do diálogo
        string[] currentDialogues = npcDialogues[npcIndex];

        if (dialogueIndex < currentDialogues.Length)
        {
            dialogText.text = currentDialogues[dialogueIndex];
        }
    }

    // Retorna o número total de diálogos para um NPC específico
    public int GetTotalDialogues(int npcIndex)
    {
        return npcDialogues[npcIndex].Length;
    }

    public void EndDialogue()
    {
        dialogCanvas.enabled = false;
    }
}
