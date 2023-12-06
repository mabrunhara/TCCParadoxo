using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))] 
public class PlayerController : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float  rotationSpeed = .8f;

    [SerializeField] private Transform pontaTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletParent;
    [SerializeField] private float bulletHitMissDistance = 25f; 

    public CharacterController controller;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction ativeInvis;
    public InputAction dashAction;
    private InputAction ativeObs;

    public bool podeAndar = true;
  
    public bool ativeCalopsita;
  
    public bool ativeCamaleao;
    public bool invisibleCD;

    public bool obsCD;
    public bool ativarObs;
    public bool visaoAguia;
    public bool podeDash = true;
    public float fireRate;
    float nextRate;

    GameObject efeitoInvisivel;
    GameObject cajado;
    GameObject perkzada;
    Perk ganhaPerk;
    GameObject jogadorSapo;
    animatorSapo animacao;
    DashScript scriptDash;



    private void Awake()
    {
        efeitoInvisivel = GameObject.Find("invisivelEfeito");
        jogadorSapo = GameObject.Find("SapoJogador");
        cajado = GameObject.Find("Cajado");
        scriptDash = GetComponent<DashScript>();
        perkzada = GameObject.Find("PerkSave");
        ganhaPerk = perkzada.GetComponent<Perk>();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        ativeInvis = playerInput.actions["Invisibility"];
        dashAction = playerInput.actions["Dash"];
        ativeObs = playerInput.actions["Xray"];

        efeitoInvisivel.SetActive(false);
        cameraTransform = Camera.main.transform;
    }

  
   
    private void OnEnable()
    {
     
       
            shootAction.performed += _ => ShootGun();
         
    
    }

    private void OnDisable()
    {
      shootAction.performed -= _ => ShootGun();
    }

    private void ShootGun()
    {
        
        if (Time.time > nextRate && cajado.activeSelf)
        {
            nextRate = Time.time + fireRate;
            RaycastHit hit;
            GameObject bullet = GameObject.Instantiate(bulletPrefab, pontaTransform.position, Quaternion.identity, bulletParent);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
            {
                bulletController.target = hit.point;
                bulletController.hit = true;

            }
            else
            {
                bulletController.target = cameraTransform.position + cameraTransform.forward * bulletHitMissDistance;
                bulletController.hit = true;
            }
        }
    }

   
    void Update()
    {
        if(shootAction.triggered && cajado.activeSelf)
        {
            jogadorSapo.GetComponent<Animator>().SetBool("isAtaque", true);
        }
        else
        {
            jogadorSapo.GetComponent<Animator>().SetBool("isAtaque", false);
        }
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if (podeAndar)
        {
            Vector2 input = moveAction.ReadValue<Vector2>();
            Vector3 move = new Vector3(input.x, 0, input.y);
            move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
            move.y = 0f;
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        if(Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed || Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed && podeAndar)
        {
            jogadorSapo.GetComponent<Animator>().SetBool("isCorre", true);
        }
        else
        {
            jogadorSapo.GetComponent<Animator>().SetBool("isCorre", false);
        }

      
        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            jogadorSapo.GetComponent<Animator>().SetBool("isCorre", false);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jogadorSapo.GetComponent<Animator>().SetBool("isPula", true);
        }
        else
        {
            jogadorSapo.GetComponent<Animator>().SetBool("isPula", false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y,0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        

        if ( Perk.pCalopsita == true && ativeCalopsita == false)
        {
            ativeCalopsita = true;
            playerSpeed += 2.5f;
        }

        if ( Perk.pCamaleao == true && ativeInvis.triggered && ativeCamaleao == false && invisibleCD == false)
        {
            StartCoroutine(Invisibilidade());
        }

        if(dashAction.triggered && podeDash)
        {
           StartCoroutine(scriptDash.Dash());
        }
        
        if(Perk.pAguia == true && ativeObs.triggered && ativarObs == false && obsCD == false && visaoAguia == false)
        {
            visaoAguia = true;
        }
        
       
    }

   


    public IEnumerator Invisibilidade()
    {
        ativeCamaleao = true;
        invisibleCD = true;
        efeitoInvisivel.SetActive(true);
        yield return new WaitForSeconds(3f);
        ativeCamaleao = false;
        efeitoInvisivel.SetActive(false);
        yield return new WaitForSeconds(20f);
        invisibleCD = false;
    }
}

