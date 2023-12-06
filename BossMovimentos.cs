using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovimentos : MonoBehaviour
{
 
    public BarraBoss bossBar;
    public Transform player;
    public LayerMask terreno, whatIsPlayer;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public int vidaMax;
    public int vidaAtual;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    bool alreadyArea;
    public float timeBetweenArea;
    public GameObject projectile;
   
    public int definicao = 0;
    public bool modoAtira;
    public bool modoArea;
   
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject ProjectilePrefab;

    GameObject cirujaFim;
    Animator animator;
    GameObject barreiraShield;
    GameObject bossBarra;
    scriptFinal fimFinal;
    GameObject dialogosdofim;
    private Vector3 startPoint;
    private const float radius = 1f;
    void Start()
    {
        cirujaFim = GameObject.Find("cirujafinal");
        dialogosdofim = GameObject.Find("NPC_F");
        fimFinal = cirujaFim.GetComponent<scriptFinal>();
        animator = GetComponent<Animator>();
        bossBarra = GameObject.Find("BarraBoss");
        player = GameObject.Find("Player").transform;
        vidaAtual = vidaMax;
        bossBar.SetMaxHealth(vidaMax);
        barreiraShield = GameObject.Find("Barreira");

        barreiraShield.SetActive(false);
        bossBarra.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInSightRange) bossBarra.SetActive(true);

        if (playerInAttackRange && playerInSightRange && modoAtira == true) AttackPlayer();
        if (playerInAttackRange && playerInSightRange && modoArea == true) SpawnProjectile(numberOfProjectiles);
       
       if (modoAtira)
        {
            barreiraShield.SetActive(true);
        }
       if(!modoAtira)
        {
            barreiraShield.SetActive(false);
        }

        if(definicao == 0 && modoArea == false && modoAtira == false)
        {
            definicao = Random.Range(0, 3);
        }

        if (definicao == 1)
        {
            modoAtira = true;
            
            StartCoroutine(ModarAtira());
        }

        if (definicao == 2)
        {
            modoArea = true;
           
            StartCoroutine(ModarArea());
        }

    }
    public IEnumerator ModarAtira()
    {
       
       
        
            yield return new WaitForSeconds(15f);
            modoAtira = false;
            definicao = 0;
        
    }
     public IEnumerator ModarArea()
        {
            startPoint = transform.position;
            yield return new WaitForSeconds(15f);
            modoArea = false;
            definicao = 0;
        }
    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;
        if (!alreadyArea)
        {
            for (int i = 0; i <= _numberOfProjectiles - 1; i++)
            {
                float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
                Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

                GameObject tmpObj = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
                tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

                angle += angleStep;
                
            }
            alreadyArea = true;
            Invoke(nameof(ResetArea), timeBetweenArea);
            animator.SetBool("isArea", true);
        }
    }

    private void ResetArea()
    {
        alreadyArea = false;
        animator.SetBool("isArea", false);
    }

    private void AttackPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            //codigo do ataque
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 4f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            animator.SetBool("isAtira", true);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("isAtira", false);
    }

    public void TakeDamage(int damage)
    {
        if (!modoAtira)
        {
            vidaAtual -= damage;
            bossBar.SetHealth(vidaAtual);
        }

        if (vidaAtual <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        fimFinal.bossMorreu = true;
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelect()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}
