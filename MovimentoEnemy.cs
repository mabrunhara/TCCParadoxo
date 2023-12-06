using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoEnemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask terreno, whatIsPlayer;
    private float tempoF = 0.5f;
    public float vida;
    public bool stun;
    public bool envenenado = false;
    bool veneno = true;
    public int danoVeneno = 5;
    public float timerVeneno = 3f;
    public bool abelhaAtive = false;
    public bool efeitoabelha = false;
    public bool ovelhaAtive = false;
    public bool estadoSono = false;
    public bool estadoStun = false;
    GameObject soninho;
    GameObject veneninho;
    //Patrulha
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float walkSpeed = 2f;

    //ataque
     public float timeBetweenAttacks;
     bool alreadyAttacked;
     public GameObject projectile;

     //Estados
     public float sightRange, attackRange;
     public bool playerInSightRange, playerInAttackRange;

    GameObject morreu;
    GameObject perkzada;
    Perk ganhaPerk;
    GameObject jogador;
    PlayerController invisible;
    DashScript dashCabra;
    GameObject spawner;
    Spawner spawnar;

     private void Awake()
     {
        morreu = GameObject.Find("Explosion");
        perkzada = GameObject.Find("PerkSave");
        ganhaPerk = perkzada.GetComponent<Perk>();
        veneninho = GameObject.Find("poison");
        soninho = GameObject.Find("soninho");
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        jogador = GameObject.Find("Player");
        invisible = jogador.GetComponent<PlayerController>();
        dashCabra = jogador.GetComponent<DashScript>();
        spawner = GameObject.Find("Spawner");
        spawnar = spawner.GetComponent<Spawner>();
        soninho.SetActive(false);
        veneninho.SetActive(false);
        morreu.SetActive(false);
       

     }

    private void Update()
    {
        //checar se o player esta no range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange && invisible.ativeCamaleao == false) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && invisible.ativeCamaleao == false && ovelhaAtive == false && stun == false) AttackPlayer();


        if(envenenado == true)
        {
            StartCoroutine("Envenenamento");
        }

        if( vida <= 0)
        {
            
            Destroy(this.gameObject, tempoF);
            spawnar.spawnCount--;

        }

        if ( abelhaAtive == true)
        {
            StartCoroutine("Lentidao");
        }

        if(abelhaAtive==false)
        {
            agent.speed = 5f;
        }

        if(ovelhaAtive == true)
        {
            StartCoroutine("Sono");
        }

        if(stun == true)
        {
            StartCoroutine("Stun");
        }
    }
    
    private void Patroling()
    {
        if (walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //calcula um ponto aleatorio no range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3 (transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, walkSpeed, terreno))
        walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Ter certeza que o enimigo nao vai se mover
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //codigo do ataque
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false; 
    }

    public void TakeDamage (int damage)
    {
        vida -= damage;

        if (vida <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
            morreu.SetActive(true);
        }
    }

    private void DestroyEnemy() 
    {
        
        Destroy(gameObject); 
    }

    private void OnDrawGizmosSelect()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player" && dashCabra.dashAtivo == true && Perk.pCabra == true && stun == false)
        {
            stun = Random.value > 0.70;
        }
        else
        {
            stun = false;
        }
    }

    IEnumerator Envenenamento()
    {
        if (veneno)
        {
            veneninho.SetActive(true);
            vida -= danoVeneno;
            veneno = false;
            yield return new WaitForSeconds(timerVeneno);
            veneno = true;
        }
    }
    IEnumerator Lentidao()
    {
        if (abelhaAtive == true)
        {
            agent.speed = 1.5f;
            yield return new WaitForSeconds(3f);
            abelhaAtive = false;
        }
       
    }
    IEnumerator Sono()
    {
        if (ovelhaAtive == true)
        {
          
            agent.speed = 0f;
            estadoSono = true;
            soninho.SetActive(true);
           
        }
        yield return new WaitForSeconds(4f);
        ovelhaAtive = false;
        estadoSono = false;
        soninho.SetActive(false);

    }
    IEnumerator Stun()
    {
        if(stun == true)
        {
            agent.speed = 0f;
            estadoStun = true;

        }
        yield return new WaitForSeconds(2f);
        stun = false;
        estadoStun = false;
    }
}