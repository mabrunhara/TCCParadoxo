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
        new string[] {"Cutia:\r\n  Cuidado forasteiro perdido, �s vezes a luz que nos guia � a mesma que nos queima� *ela fecha os olhos� acho que isso deve ter sido bem mais legal na cabe�a dela.* ",
                       "Cutia:\r\n Esta floresta est� rodeada de esp�ritos daqueles que foram tolos o suficiente para deflagrar esse solo sagrado, vinculando suas almas �s ra�zes das �rvores m�gicas daqui pertencentes, e agora os fantasmas servem como protetores do que outrora tentaram destruir.",
                        "Cutia:\r\n Cuidado amigo, � perigoso ir sozinho, pegue isso. * ela estende alguns gravetos e pedras que acabou de pegar do ch�o� acho que n�o preciso disso. *"},

        //Gamba
        new string[] {"Aurita:\r\n OIIIIIII! Eu sou a maior alquimista de todos os reinos e nada pode me impedir. *ela tenta fazer uma risada maligna* Desculpa, ainda t� treinando.",
                      "Aurita:\r\n Sabia que eu n�o sou uma fuinha?",
                      "Aurita:\r\n Na verdade sou uma gamb�, mas o nome **irm�os FuB�** n�o era muito bom para os neg�cios. **Irm�os FuFu** soa muito melhor, n�o? Enfim� ",
                      "Aurita:\r\n Esse solo parece corrompido, como se algu�m tivesse apagado algo que n�o deveria� talvez um mago muito poderoso� ou algu�m que esqueceu um ponto e v�rgula. "},

        //Trigas
        new string [] {"Trigas:\r\n Sua jornada chega perto do seu fim pequenino.","Trigas:\r\n N�o se acanhe e use tudo o que aprendeu.","Trigas:\r\n Eu vou ficar aqui... Bem longe do conflito.","Trigas:\r\n Mas conte com meu apoio moral."},
        
        // Adicione mais di�logos conforme necess�rio
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

        // Adiciona cada linha de di�logo do NPC ao texto do di�logo
        string[] currentDialogues = npcDialogues[npcIndex];

        if (dialogueIndex < currentDialogues.Length)
        {
            dialogText.text = currentDialogues[dialogueIndex];
            lastDialogueIndex = dialogueIndex; // Save the last dialogue index
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

    // M�todo para obter o �ltimo �ndice de di�logo
    public int GetLastDialogueIndex()
    {
        return lastDialogueIndex;
    }
}