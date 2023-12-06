using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Perks : MonoBehaviour
{
    public Sprite[] perks;
    GameObject perkS;
    GameObject quests;
    GameObject perkSave;
    Perk ganhaPerks;
    QuestManager complete;
    private SpriteRenderer render;
    public bool completou;
  
   
   
    private Sprite abelhaSpr, ursoSpr, cabraSpr, ovelhaSpr, camaleaoSpr, morcegoSpr, calopsitaSpr, aguiaSpr, cobraSpr;
    public bool pegou;
   

    void Start()
    {
        quests = GameObject.Find("Quest");
        complete = quests.GetComponent<QuestManager>();
        render = GetComponent<SpriteRenderer>();
      
        abelhaSpr = Resources.Load<Sprite>("bumblebeet");
        ursoSpr = Resources.Load<Sprite>("ursot");
        cabraSpr = Resources.Load<Sprite>("cabrat");
        ovelhaSpr = Resources.Load<Sprite>("ovelhat");
        camaleaoSpr = Resources.Load<Sprite>("camaleaot");
        morcegoSpr = Resources.Load<Sprite>("ratoquevoat");
        calopsitaSpr = Resources.Load<Sprite>("calopsitat");
        aguiaSpr = Resources.Load<Sprite>("aguiat");
        cobraSpr = Resources.Load<Sprite>("crobat");
        perkS = GameObject.Find("PerkScreen");
        perkSave = GameObject.Find("PerkSave");
        ganhaPerks = perkSave.GetComponent<Perk>();

       
        
      
    }

 
    void Update()
    {
        if (complete.collectedItemCount == 5 && completou == false)
        {
            completou = true;
           
            Show();
        }

        if (pegou ==true )
        {
            complete.collectedItemCount = 0;
            Fecha();
        }

    }


    void Show()
    {

            perkS.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = perks[Random.Range(0, perks.Length)];
          
            
        
    }

    void Fecha()
    {
        perkS.SetActive(false);
    }

    void OnMouseDown()
    {

        if (render.sprite == abelhaSpr)
        {
            Perk.pAbelha = true;
           
        }

        if (render.sprite == ursoSpr)
        {
            Perk.pUrso = true;

        }

        if(render.sprite == cabraSpr)
        {
            Perk.pCabra = true;
        }

        if(render.sprite == ovelhaSpr)
        {
            Perk.pOvelha = true;
        }

        if(render.sprite == cobraSpr)
        {
            Perk.pCobra = true;
        }

        if(render.sprite == morcegoSpr)
        {
            Perk.pMorcego = true;
        }

        if(render.sprite == camaleaoSpr)
        {
            Perk.pCamaleao = true;
        }

        if(render.sprite == aguiaSpr)
        {
            Perk.pAguia = true;
        }

        if(render.sprite == calopsitaSpr)
        {
            Perk.pCalopsita = true;
        }

        pegou = true;
    }
}
