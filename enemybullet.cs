using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    private float timeToDestroy = 3f;
    public int enemyDamage;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent<VidaPlayer>(out VidaPlayer playerComponent))
        {
            playerComponent.TakeDamage(enemyDamage);
            Destroy(gameObject);
        }

        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
        
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
