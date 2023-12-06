using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtaque : MonoBehaviour
{
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject ProjectilePrefab;

    private Vector3 startPoint;
    private const float radius = 1f;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            startPoint = transform.position;
            SpawnProjectile(numberOfProjectiles);
        }
    }

    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for(int i  = 0; i<= _numberOfProjectiles -1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

            angle += angleStep;
        }
    }
}

