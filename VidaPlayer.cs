using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

   
    public bool addUrso = false;
    public BarraDeVida healthBar;
    GameObject gameOver;
    GameObject perkzada;
    Perk ganhaPerk;

    void Start()
    {
        gameOver = GameObject.Find("GameOver");
        perkzada = GameObject.Find("PerkSave");
        ganhaPerk = perkzada.GetComponent<Perk>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gameOver.SetActive(false);
    }

   
    void FixedUpdate()
    {
      if ( Perk.pUrso == true && addUrso ==false )
        {
            addUrso=true;
            HealDamage();
        }
    }

    public void HealDamage()
    { 
        maxHealth = 125;
        currentHealth += 25;
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damageAmount)
    { 
        currentHealth -= damageAmount;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            gameOver.SetActive(true);
            Destroy(this.gameObject);
        }

    }
}
