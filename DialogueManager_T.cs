using UnityEngine;
using UnityEngine.UI;

[SerializeField] public class DialogueManager_T : MonoBehaviour
{
    public static DialogueManager_T Instance;

    public Canvas dialogCanvas;
    public Text dialogText;

    private string[][] npcDialogues =
    {
        new string[] {"Voz Misteriosa:\r\n ... Oi?" , "Voz Misteriosa:\r\n ... Olá?" ,"Bufus:\r\n ???" ,"Voz Misteriosa:\r\n Espera, como você veio parar aqui?", "Bufus:\r\n Onde...", "Bufus:\r\n Onde eu estou?" , "Voz Misteriosa:\r\n Perdão, não me apresentei." , "Ciruja:\r\n Meu nome é Ciruja, e eu sou o responsável pela maravilhosa, porém perigosa, terra de Agnesis." ,
        "Bufus:\r\n Professor?", "Ciruja:\r\n Ahh, interessante..." , "Ciruja:\r\n Então quer dizer que você já conhece um dos fragmentos da minha existência?" , "Bufus:\r\n Professor, eu não estou entendendo... O que aconteceu com você?", "Ciruja:\r\n Meu pupilo, o Ciruja que você conhece não sou eu, mas sim uma parte de mim." , "Ciruja:\r\n Eu sou um mago da programação. Sou responsável pela criação e manutenção de todas as realidades existentes." ,
        "Ciruja:\r\n Eu criei pequenos fragmentos de minha existência e depositei em todas as realidades que criei até hoje." , "Ciruja:\r\n Me tornei um ser plurifacetado em cada um desses universos. Em alguns sou médico, engenheiro, psicólogo...","Ciruja:\r\n E aparentemente na sua realidade eu sou um professor.","Ciruja:\r\n Acho que por isso que você e essa escola apareceram aqui." , "Bufus:\r\n isso é algum tipo de piada?", "Bufus:\r\n: você é meu professor de programação da escola. E eu nem sei oque 'plurifacetado' significa.",
        "Ciruja:\r\n HAHAHA, eu entendo sua confusão, pupilo. Mas acredite, estou tão confuso quanto você." , "Ciruja:\r\n ...","Ciruja:\r\n Imagine todas as realidades como um grande maquinário, cada uma sendo alguma engrenagem porca ou rebite.","Ciruja:\r\n Eu sou a pessoa que montou todo esse maquinário, tendo certeza que todas as peças se encaixam e funcionam perfeitamente juntas.", "Ciruja:\r\n E Agnesis é a oficina onde eu me abriguei para trabalhar em tudo isso. Nessa oficina eu tenho todos os equipamentos que preciso e posso trabalhar tranquilamente",
        "Bufus:\r\n e esse é o lugar onde estamos agora?","Ciruja:\r\n Isso, exatamente. Você aprende rápido.","Ciruja:\r\n ...","Ciruja:\r\n Mas existe um porém em tudo isso, pupilo...","Ciruja:\r\n Ninguém nunca foi capaz de entrar aqui, muito menos sem minha permissão.", "Bufus:\r\n ...","Ciruja:\r\n Eu...","Ciruja:\r\n Eu acredito que cometi algum erro na programação das realidades, o que criou uma fenda dimensional que te trouxe até aqui.","Bufus:\r\n O Ciruja que eu conheço nunca comete erros nos seus códigos...","Ciruja:\r\n HAHAHA, isso porque eu criei todos os meus fragmentos para sem perfeitos, e não para serem um espelho de mim.",
        "Ciruja:\r\n Até entidades como eu erram, meu pupilo, assim é a vida.","Bufus:\r\n Mas o que tudo isso significa?","Bufus:\r\n Não quero te menosprezar, Ciruja, adorei como você decorou sua 'oficina', mas eu quero voltar pra casa...","Ciruja:\r\n Certo, eu entendo, meu pupilo...","Ciruja:\r\n Antes de tudo, preciso que você aprenda algumas coisas sobre Agnesis.","Ciruja:\r\n Como eu te disse, esta é uma terra maravilhosa, mas também muito perigosa.","Ciruja:\r\n Eu tenho uma ideia de como você conseguirá voltar para casa, mas para isso, você precisará passar por três locais e enfrentar os perigos de cada um deles.",
        "Ciruja:\r\n Se você conseguiu ser a única pessoa a chegar aqui, tenho certeza que é capaz de derrotar alguns monstros","Ciruja:\r\n Para te ajudar com isso, te darei um pequeno presente","Ciruja:\r\n Esse é um dos cajados da minha coleção, peguei ele da realidade onde sou um rei tritão.. HAHA","Bufus:\r\n ...","Bufus:\r\n Isso é sério?","Ciruja:\r\n Vai me dizer que se você tivesse toda realidade à sua mercê, não pegaria um souvenir de cada uma delas?", "Bufus:\r\n Você tem um ponto.",
        "Ciruja:\r\n Mas bom, vamos lá...","Ciruja:\r\n Para o cajado funcionar, aperte <BOTÃO_ESQUERDO_MOUSE> ou <GATILHO_DIREITO_CONTROLE>. É só mirar com o <MOUSE>/<JOYSTICK_DIREITO> para seus inimigos e BOOM, estrago feito.","Ciruja:\r\n: Também é importante que você saiba sobre como se portar nesse mundo... Use <WASD>/<JOYSTICK_ESQUERDO> para andar por aí e <E> para interagir com objectos.", "Ciruja:\r\n Também coloquei as instruções na lousa","Bufus:\r\n Parece fácil, mas o que faço agora?", "Ciruja:\r\n Enquanto falava com você, criei alguns portais que te levarão para os locais corretos, você só precisa achá-los",
        "Ciruja:\r\n Vá pupilo! Voe em sua nova aventura! Te esperarei nos próximos locais.", ""},
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
