using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deus : MonoBehaviour
{
 public float giratorio;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*giratorio);        
    }
}
