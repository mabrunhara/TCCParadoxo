using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        // Adicione mais di�logos conforme necess�rio 
        
        //Castor
        new string[] {"Katimirim:\r\n Hmmm� AAAAAAH! Que susto, voc� quase me mata do cora��o!",
                      "Katimirim:\r\n Ol� nobre guerreiro, fico feliz de ver uma boa alma por essas florestas assombradas!",
                      "Katimirim:\r\n Na verdade, se n�o for pedir muito, poderia coletar as rel�quias de polum� digo � hmmm, ",
                      "Katimirim:\r\n esmeraldas do caos� digo� hmmm, as joias do infinito� digo� hmmm, aaaaah. ",
                      "Katimirim:\r\n Ah, voc� entendeu, pegue umas pedrinhas coloridas e traga pra mim, e quem sabe eu consigo te ajudar.",
                      "Aviso ao player:\r\n Ap�s a quest finalizada procure o portal para continuar a sua aventura em Agnesis."},
                        
        //Fuinha
        new string[] {"Wipphert:\r\n OL� CLIENTE! Todo dia � uma oportunidade, e voc� acaba de encontrar a maior da sua vida!",
                      "Wipphert e Auritata:\r\n Nossa loja tem os melhores produtos de todo o mundo e pelo pre�o mais barato de todos, 1 �nico favorzinho! E a�, o que acha?  " +
                      "Bufus:\r\n  *os dois irm�os falam ao mesmo tempo, isso me d� um pouco de medo* ",
                      "Wipphert:\r\n Ent�o parceiro, parada simples, parada boa: d� uma andada, bate em uns bichos e o mais importante: se tu achar umas barras de metal ou algo do tipo,",
                      "Wipphert:\r\n S� trazer aqui que eu vou dar uma renovada em ti� Por conta da casa, relaxa.",
                      "Bufus:\r\n *algo me diz que ele t� mentindo*",
                      "Aviso ao player:\r\n Ap�s a quest finalizada procure o portal para continuar a sua aventura em Agnesis."},

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
