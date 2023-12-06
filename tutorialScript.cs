using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    private float timeToDestroy = 200f;
    GameObject intro;
    GameObject playerCajado;
    GameObject jogador;
    GameObject ciruja;
    GameObject telapreta;
    PlayerController codigoPlayer;
    public bool tutorialPassou;
    void Start()
    {
        ciruja = GameObject.Find("CirujaTutor");
        telapreta = GameObject.Find("telapreta");
        jogador = GameObject.Find("Player");
        codigoPlayer = jogador.GetComponent<PlayerController>();
        playerCajado = GameObject.Find("Cajado");
        intro = GameObject.Find("CanvasIntro");
        Invoke(nameof(Cutscene), timeToDestroy);
        playerCajado.SetActive(false);
        codigoPlayer.podeAndar = false;
        ciruja.SetActive(false);
    }

    
    void Update()
    {
        if(Input.anyKey)
        {
            Cutscene();
        }
        if (!intro.activeSelf)
        {
            
            ciruja.SetActive(true);
        }
        
    }

    void Cutscene()
    {
        intro.SetActive(false);
        
    }
}
