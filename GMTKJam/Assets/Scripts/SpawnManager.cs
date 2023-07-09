using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnTransform;

    [SerializeField]
    GameObject[] enemyGO;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if (FindObjectsOfType<Enemy>().Length >= 9)
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator EnemySpawner()
    {
        while (true)
        {
            Instantiate(enemyGO[Random.Range(0, enemyGO.Length)], spawnTransform[Random.Range(0, spawnTransform.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(7f);
        }
    
    }
}
