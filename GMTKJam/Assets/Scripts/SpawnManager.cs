using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnTransform;

    [SerializeField]
    GameObject[] enemyGO;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
        
    }

   

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            Instantiate(enemyGO[Random.Range(0, enemyGO.Length)], spawnTransform[Random.Range(0, spawnTransform.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    
    }
}
