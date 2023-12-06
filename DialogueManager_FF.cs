using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class DialogueManager_FF : MonoBehaviour
{
    public static DialogueManager_FF Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        // Adicione mais diálogos conforme necessário 
       
        new string[] {"Ciruja:\r\n Mil perdões Bufo…",
                      "Ciruja:\r\n Eu fui descuidado e um mago me infectou com um trojan, uma das formas mais malignas de maldição.",
                      "Ciruja:\r\n Este não sou eu de verdade. A única forma de voltar ao seu mundo…",
                      "Ciruja:\r\n É me reiniciando… Formatando minha existência… ",
                      "Ciruja:\r\n Você precisa fazer isso Bufus, pelo bem de todo o universo, ou eu acabarei com tudo.",
        "APERTE INTERAÇÂO PARA FORMATAR EXISTÊNCIA", ""},
                        
       

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
