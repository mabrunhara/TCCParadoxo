using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class DialogueManager_FF : MonoBehaviour
{
    public static DialogueManager_FF Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        // Adicione mais di�logos conforme necess�rio 
       
        new string[] {"Ciruja:\r\n Mil perd�es Bufo�",
                      "Ciruja:\r\n Eu fui descuidado e um mago me infectou com um trojan, uma das formas mais malignas de maldi��o.",
                      "Ciruja:\r\n Este n�o sou eu de verdade. A �nica forma de voltar ao seu mundo�",
                      "Ciruja:\r\n � me reiniciando� Formatando minha exist�ncia� ",
                      "Ciruja:\r\n Voc� precisa fazer isso Bufus, pelo bem de todo o universo, ou eu acabarei com tudo.",
        "APERTE INTERA��O PARA FORMATAR EXIST�NCIA", ""},
                        
       

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
