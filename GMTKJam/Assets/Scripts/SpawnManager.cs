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

    [SerializeField]
    [Range(0,100)]
    float spawnTime;

    public bool rountineStarted;
    private void Awake()
    {
        gameManager =GameObject.FindObjectOfType<GameManager>();
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
        rountineStarted = true;


        while (gameManager.startGame)
        {
            Instantiate(enemyGO[Random.Range(0, enemyGO.Length)], spawnTransform[Random.Range(0, spawnTransform.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    
    }
}
