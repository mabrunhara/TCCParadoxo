using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        // Adicione mais diálogos conforme necessário 
        
        //Castor
        new string[] {"Katimirim:\r\n Hmmm… AAAAAAH! Que susto, você quase me mata do coração!",
                      "Katimirim:\r\n Olá nobre guerreiro, fico feliz de ver uma boa alma por essas florestas assombradas!",
                      "Katimirim:\r\n Na verdade, se não for pedir muito, poderia coletar as relíquias de polum… digo … hmmm, ",
                      "Katimirim:\r\n esmeraldas do caos… digo… hmmm, as joias do infinito… digo… hmmm, aaaaah. ",
                      "Katimirim:\r\n Ah, você entendeu, pegue umas pedrinhas coloridas e traga pra mim, e quem sabe eu consigo te ajudar.",
                      "Aviso ao player:\r\n Após a quest finalizada procure o portal para continuar a sua aventura em Agnesis."},
                        
        //Fuinha
        new string[] {"Wipphert:\r\n OLÁ CLIENTE! Todo dia é uma oportunidade, e você acaba de encontrar a maior da sua vida!",
                      "Wipphert e Auritata:\r\n Nossa loja tem os melhores produtos de todo o mundo e pelo preço mais barato de todos, 1 único favorzinho! E aí, o que acha?  " +
                      "Bufus:\r\n  *os dois irmãos falam ao mesmo tempo, isso me dá um pouco de medo* ",
                      "Wipphert:\r\n Então parceiro, parada simples, parada boa: dá uma andada, bate em uns bichos e o mais importante: se tu achar umas barras de metal ou algo do tipo,",
                      "Wipphert:\r\n Só trazer aqui que eu vou dar uma renovada em ti… Por conta da casa, relaxa.",
                      "Bufus:\r\n *algo me diz que ele tá mentindo*",
                      "Aviso ao player:\r\n Após a quest finalizada procure o portal para continuar a sua aventura em Agnesis."},

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
