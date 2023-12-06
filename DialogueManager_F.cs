using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class DialogueManager_F : MonoBehaviour
{
    public static DialogueManager_F Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        new string[] {"Ciruja:\r\n Sinto muito pequenino, mas voc� n�o entenderia...","Ciruja:\r\n Infelizmente a �nica forma de retornar a sua casa � passando por mim...", "Ciruja:\r\n E sejamos sensatos, isso nunca ir� acontecer...","Ciruja:\r\n Ent�o volte de onde veio ou se prepare para perder.", ""},
        
        // Adicione mais di�logos conforme necess�rio
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

        // Adiciona cada linha de di�logo do NPC ao texto do di�logo
        string[] currentDialogues = npcDialogues[npcIndex];

        if (dialogueIndex < currentDialogues.Length)
        {
            dialogText.text = currentDialogues[dialogueIndex];
        }
    }

    // Retorna o n�mero total de di�logos para um NPC espec�fico
    public int GetTotalDialogues(int npcIndex)
    {
        return npcDialogues[npcIndex].Length;
    }

    public void EndDialogue()
    {
        dialogCanvas.enabled = false;
    }
}
