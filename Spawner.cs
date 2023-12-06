using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] inimigos;
    public float spawnTime;
    public int spawnCount;
    [SerializeField] public int minX;
    [SerializeField] public int maxX;
    [SerializeField] public int minZ;
    [SerializeField] public int maxZ;
    [SerializeField] public int Ipisilon;

    
    void Start()
    {
            StartCoroutine(Spawnar()); 
    }
   
    IEnumerator Spawnar()
    {
        if (spawnCount < 8)
        {
            yield return new WaitForSeconds(10);
            int randomIndex = Random.Range(0, inimigos.Length);
            Vector3 randomSpawnPoint = new Vector3(Random.Range(minX, maxX), Ipisilon, Random.Range(minZ, maxZ));
            Instantiate(inimigos[randomIndex], randomSpawnPoint, Quaternion.identity);
            StartCoroutine(Spawnar());
            spawnCount++;
        }
    }
}
