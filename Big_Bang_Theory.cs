using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Big_Bang_Theory : MonoBehaviour
{
    public float humor = 1f;
    public Animator transition;
    

   public void Bazinga()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
      
    }

     IEnumerator LoadLevel(int levelindex)

    {
        
        yield return new WaitForSeconds(humor);
        SceneManager.LoadScene(levelindex);
        transition.SetTrigger("Start");
    }

    public void risos()
    {
        Debug.Log("Fugiu HAHAHahahhahahahahahhhhahah");
        Application.Quit();
    }

   

}
