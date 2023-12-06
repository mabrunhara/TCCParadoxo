using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class telaDerrota : MonoBehaviour
{
   public void LoadLoop()
    {
        SceneManager.LoadScene("Floresta");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu 01.11");
    }
}
