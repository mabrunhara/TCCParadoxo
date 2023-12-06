using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptRaioX : MonoBehaviour
{
    public Material[] material;
    public int x;
   
    Renderer rend;
    GameObject jogador;
    PlayerController aguiaPerk;
    

    void Start()
    {
        jogador = GameObject.Find("Player");
        aguiaPerk = jogador.GetComponent<PlayerController>();
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    
    void Update()
    {
        rend.sharedMaterial = material[x];
        if(aguiaPerk.visaoAguia == true)
        {
            StartCoroutine(Observacao());
        }
    }
    public IEnumerator Observacao()
    {
        aguiaPerk.ativarObs = true;
        aguiaPerk.obsCD = true;
        x = 1;
        yield return new WaitForSeconds(3f);
        x = 0;
        aguiaPerk.ativarObs = false;
        aguiaPerk.visaoAguia = false;
        yield return new WaitForSeconds(20f);
        aguiaPerk.obsCD = false;
        
    }
}
