using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject bulletDecal;

    public int damage;
    private float speed = 50f;
    private float timeToDestroy = 3f;
 
    public bool buffVamp = false;
    public bool buffCobra = false;
    public Vector3 target { get; set;}
    public bool hit { get; set; }
    GameObject perkzada;
    Perk ganhaPerk;
    GameObject playerVida;
    VidaPlayer vida;
    private void Start()
    {
        perkzada = GameObject.Find("PerkSave");
        ganhaPerk = perkzada.GetComponent<Perk>();
        playerVida = GameObject.Find("Player");
        vida = playerVida.GetComponent<VidaPlayer>();

        if(SceneManager.GetActiveScene().name == "Floresta")
        {
            damage = 10;
        }

        if(SceneManager.GetActiveScene().name == "Codigos")
        {
            damage = 15;
            
        }

        if (SceneManager.GetActiveScene().name == "universo")
        {
            damage = 20;
           
        }
    }


    private void FixedUpdate()
    {
        if (Perk.pMorcego ==true && buffVamp == false)
        {
            damage += damage * 15/100;
            buffVamp = true;
        }

     
    }
    private void OnEnable()
   {
     Destroy(gameObject, timeToDestroy);
   }

   void Update()
   {
     transform.position = Vector3.MoveTowards(transform.position,target, speed * Time.deltaTime);
     if ( !hit && Vector3.Distance(transform.position, target) < .01f)
     {
        Destroy(gameObject);
     }

     
   
   }

   private void OnTriggerEnter(Collider collision)
   {

        if(collision.TryGetComponent<MovimentoEnemy>(out MovimentoEnemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage);

            if(Perk.pCobra == true)
            {
                enemyComponent.envenenado = true;
            }

            if (Perk.pMorcego ==true)
            {
                vida.currentHealth += damage * 15 / 100;
            }

            if (Perk.pAbelha == true && enemyComponent.abelhaAtive == false)
            {
                enemyComponent.abelhaAtive = true;
               
            }

            if(Perk.pOvelha==true && enemyComponent.ovelhaAtive == false)
            {
                enemyComponent.ovelhaAtive = Random.value > 0.75;
            }
            if(enemyComponent.estadoSono == true)
            {
                enemyComponent.estadoSono = false;
                enemyComponent.ovelhaAtive = false;
            }
           
        }

        if (collision.TryGetComponent<BossMovimentos>(out BossMovimentos bossComponent))
        {
            bossComponent.TakeDamage(damage);
        }

        Destroy(this.gameObject);
   }

}
