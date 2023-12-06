using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perk : MonoBehaviour
{
  public static bool pUrso, pAbelha, pCabra, pOvelha, pCobra, pAguia, pCalopsita, pCamaleao, pMorcego;
    
    void OnSceneLoaded(Scene Floresta)
    {
        pUrso = false;
        pAbelha = false;
        pCabra = false;
        pOvelha = false;
        pCobra = false;
        pAguia = false;
        pCalopsita = false;
        pCamaleao = false;
        pMorcego = false;
    }
  
}
