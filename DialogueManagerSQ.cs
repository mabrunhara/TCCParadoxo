using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class DialogueManagerSQ : MonoBehaviour
{
    public static DialogueManagerSQ Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        
        //Capivara
        new string[] {"Cutia:\r\n  Cuidado forasteiro perdido, às vezes a luz que nos guia é a mesma que nos queima… *ela fecha os olhos… acho que isso deve ter sido bem mais legal na cabeça dela.* ",
                       "Cutia:\r\n Esta floresta está rodeada de espíritos daqueles que foram tolos o suficiente para deflagrar esse solo sagrado, vinculando suas almas às raízes das árvores mágicas daqui pertencentes, e agora os fantasmas servem como protetores do que outrora tentaram destruir.",
                        "Cutia:\r\n Cuidado amigo, é perigoso ir sozinho, pegue isso. * ela estende alguns gravetos e pedras que acabou de pegar do chão… acho que não preciso disso. *"},

        //Gamba
        new string[] {"Aurita:\r\n OIIIIIII! Eu sou a maior alquimista de todos os reinos e nada pode me impedir. *ela tenta fazer uma risada maligna* Desculpa, ainda tô treinando.",
                      "Aurita:\r\n Sabia que eu não sou uma fuinha?",
                      "Aurita:\r\n Na verdade sou uma gambá, mas o nome **irmãos FuBá** não era muito bom para os negócios. **Irmãos FuFu** soa muito melhor, não? Enfim… ",
                      "Aurita:\r\n Esse solo parece corrompido, como se alguém tivesse apagado algo que não deveria… talvez um mago muito poderoso… ou alguém que esqueceu um ponto e vírgula. "},

        //Trigas
        new string [] {"Trigas:\r\n Sua jornada chega perto do seu fim pequenino.","Trigas:\r\n Não se acanhe e use tudo o que aprendeu.","Trigas:\r\n Eu vou ficar aqui... Bem longe do conflito.","Trigas:\r\n Mas conte com meu apoio moral."},
        
        // Adicione mais diálogos conforme necessário
    };

    private int lastDialogueIndex = -1; // To store the last dialogue index

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
            lastDialogueIndex = dialogueIndex; // Save the last dialogue index
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

    // Método para obter o último índice de diálogo
    public int GetLastDialogueIndex()
    {
        return lastDialogueIndex;
    }
}