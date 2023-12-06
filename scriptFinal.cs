using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptFinal : MonoBehaviour
{
    GameObject boss;
    BossMovimentos scriptBoss;
    GameObject npcFim;

    public bool bossMorreu = false;
    // Start is called before the first frame update
    void Start()
    {
        npcFim = GameObject.Find("NPC_F");
        boss = GameObject.Find("Boss");
        
        npcFim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(bossMorreu)
        {
            npcFim.SetActive(true);
        }
    }
}
