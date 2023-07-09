using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    Transform player;
    bool spawned;

    [SerializeField]
    Projectile projectile;

    [SerializeField]
    Transform spawnPoint;

    Vector3 target;

    float time;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CharacterController>().transform;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.startGame == true)
        {
            if (time <= 1.5f)
            {
                time += Time.deltaTime;

            }
            else if (time >= 1.5f)
            {
                time = 0;
                Shooting();
            }

        }
       
    }
    void Shooting()
    {
        Instantiate(projectile, spawnPoint.position, transform.rotation);
    }

}
