using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashScript : MonoBehaviour
{
    PlayerController moveScript;
    
    public float dashSpeed;
    public float dashTime;
    public float dashLenght;
    public bool dashAtivo = false;
    
  
    private void Start()
    {
       moveScript = GetComponent<PlayerController>();
    }

    private void Update()
    {
       
    }

    public IEnumerator Dash()
    {
        float startTime = Time.time;
      
        while(Time.time < startTime + dashTime)
        {
            Vector3 moveDirection = transform.forward * dashLenght;
            dashAtivo = true;
            moveScript.controller.Move(moveDirection * Time.deltaTime * dashSpeed);
            moveScript.podeDash = false;
            yield return new WaitForSeconds(0.5f);
            dashAtivo = false;
            yield return new WaitForSeconds(2.5f);
            moveScript.podeDash = true;
            yield break;
           
           
        }
         
 
    }
}
