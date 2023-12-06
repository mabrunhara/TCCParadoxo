using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;
public class MudaCamera : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
   [SerializeField] private int camPriority = 10;

   [SerializeField] private Canvas thirdPersonCanvas;
   [SerializeField] private Canvas aimCanvas;
   private InputAction aimAction;
   private CinemachineVirtualCamera virtualCamera;

   private void Awake()
   {
     virtualCamera = GetComponent<CinemachineVirtualCamera>();
     aimAction = playerInput.actions["Aim"];
   }

   private void OnEnable()
   {
    aimAction.performed += _ => StartAim();
    aimAction.canceled += _ => CancelAim();
   }

   private void OnDisable()
   {
    aimAction.performed -= _ => StartAim();
    aimAction.canceled -= _ => CancelAim();
   }

   private void StartAim()
   {
    virtualCamera.Priority += camPriority;
    aimCanvas.enabled = true;
    thirdPersonCanvas.enabled = false;
   }

   private void CancelAim()
   {
    virtualCamera.Priority -= camPriority;
    aimCanvas.enabled = false;
    thirdPersonCanvas.enabled = true;
   }


}
