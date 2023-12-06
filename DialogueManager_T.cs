using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class DialogueManager_T : MonoBehaviour
{
    public static DialogueManager_T Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        new string[] {"Voz Misteriosa:\r\n ... Oi?" , "Voz Misteriosa:\r\n ... Ol�?" ,"Bufus:\r\n ???" ,"Voz Misteriosa:\r\n Espera, como voc� veio parar aqui?", "Bufus:\r\n Onde...", "Bufus:\r\n Onde eu estou?" , "Voz Misteriosa:\r\n Perd�o, n�o me apresentei." , "Ciruja:\r\n Meu nome � Ciruja, e eu sou o respons�vel pela maravilhosa, por�m perigosa, terra de Agnesis." ,
        "Bufus:\r\n Professor?", "Ciruja:\r\n Ahh, interessante..." , "Ciruja:\r\n Ent�o quer dizer que voc� j� conhece um dos fragmentos da minha exist�ncia?" , "Bufus:\r\n Professor, eu n�o estou entendendo... O que aconteceu com voc�?", "Ciruja:\r\n Meu pupilo, o Ciruja que voc� conhece n�o sou eu, mas sim uma parte de mim." , "Ciruja:\r\n Eu sou um mago da programa��o. Sou respons�vel pela cria��o e manuten��o de todas as realidades existentes." ,
        "Ciruja:\r\n Eu criei pequenos fragmentos de minha exist�ncia e depositei em todas as realidades que criei at� hoje." , "Ciruja:\r\n Me tornei um ser plurifacetado em cada um desses universos. Em alguns sou m�dico, engenheiro, psic�logo...","Ciruja:\r\n E aparentemente na sua realidade eu sou um professor.","Ciruja:\r\n Acho que por isso que voc� e essa escola apareceram aqui." , "Bufus:\r\n isso � algum tipo de piada?", "Bufus:\r\n: voc� � meu professor de programa��o da escola. E eu nem sei oque 'plurifacetado' significa.",
        "Ciruja:\r\n HAHAHA, eu entendo sua confus�o, pupilo. Mas acredite, estou t�o confuso quanto voc�." , "Ciruja:\r\n ...","Ciruja:\r\n Imagine todas as realidades como um grande maquin�rio, cada uma sendo alguma engrenagem porca ou rebite.","Ciruja:\r\n Eu sou a pessoa que montou todo esse maquin�rio, tendo certeza que todas as pe�as se encaixam e funcionam perfeitamente juntas.", "Ciruja:\r\n E Agnesis � a oficina onde eu me abriguei para trabalhar em tudo isso. Nessa oficina eu tenho todos os equipamentos que preciso e posso trabalhar tranquilamente",
        "Bufus:\r\n e esse � o lugar onde estamos agora?","Ciruja:\r\n Isso, exatamente. Voc� aprende r�pido.","Ciruja:\r\n ...","Ciruja:\r\n Mas existe um por�m em tudo isso, pupilo...","Ciruja:\r\n Ningu�m nunca foi capaz de entrar aqui, muito menos sem minha permiss�o.", "Bufus:\r\n ...","Ciruja:\r\n Eu...","Ciruja:\r\n Eu acredito que cometi algum erro na programa��o das realidades, o que criou uma fenda dimensional que te trouxe at� aqui.","Bufus:\r\n O Ciruja que eu conhe�o nunca comete erros nos seus c�digos...","Ciruja:\r\n HAHAHA, isso porque eu criei todos os meus fragmentos para sem perfeitos, e n�o para serem um espelho de mim.",
        "Ciruja:\r\n At� entidades como eu erram, meu pupilo, assim � a vida.","Bufus:\r\n Mas o que tudo isso significa?","Bufus:\r\n N�o quero te menosprezar, Ciruja, adorei como voc� decorou sua 'oficina', mas eu quero voltar pra casa...","Ciruja:\r\n Certo, eu entendo, meu pupilo...","Ciruja:\r\n Antes de tudo, preciso que voc� aprenda algumas coisas sobre Agnesis.","Ciruja:\r\n Como eu te disse, esta � uma terra maravilhosa, mas tamb�m muito perigosa.","Ciruja:\r\n Eu tenho uma ideia de como voc� conseguir� voltar para casa, mas para isso, voc� precisar� passar por tr�s locais e enfrentar os perigos de cada um deles.",
        "Ciruja:\r\n Se voc� conseguiu ser a �nica pessoa a chegar aqui, tenho certeza que � capaz de derrotar alguns monstros","Ciruja:\r\n Para te ajudar com isso, te darei um pequeno presente","Ciruja:\r\n Esse � um dos cajados da minha cole��o, peguei ele da realidade onde sou um rei trit�o.. HAHA","Bufus:\r\n ...","Bufus:\r\n Isso � s�rio?","Ciruja:\r\n Vai me dizer que se voc� tivesse toda realidade � sua merc�, n�o pegaria um souvenir de cada uma delas?", "Bufus:\r\n Voc� tem um ponto.",
        "Ciruja:\r\n Mas bom, vamos l�...","Ciruja:\r\n Para o cajado funcionar, aperte <BOT�O_ESQUERDO_MOUSE> ou <GATILHO_DIREITO_CONTROLE>. � s� mirar com o <MOUSE>/<JOYSTICK_DIREITO> para seus inimigos e BOOM, estrago feito.","Ciruja:\r\n: Tamb�m � importante que voc� saiba sobre como se portar nesse mundo... Use <WASD>/<JOYSTICK_ESQUERDO> para andar por a� e <E> para interagir com objectos.", "Ciruja:\r\n Tamb�m coloquei as instru��es na lousa","Bufus:\r\n Parece f�cil, mas o que fa�o agora?", "Ciruja:\r\n Enquanto falava com voc�, criei alguns portais que te levar�o para os locais corretos, voc� s� precisa ach�-los",
        "Ciruja:\r\n V� pupilo! Voe em sua nova aventura! Te esperarei nos pr�ximos locais.", ""},
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
