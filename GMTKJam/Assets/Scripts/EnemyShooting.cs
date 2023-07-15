using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    Transform player;

    public bool canShoot;
    [SerializeField]
    EnemyProjectile projectile;

    [SerializeField]
    Transform spawnPoint;

    Vector3 target;

    float time;
    Animator animator;

    GameManager gameManager;

    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();  
        player = FindObjectOfType<CharacterController>().transform;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDIR = spawnPoint.transform.InverseTransformPoint(player.transform.position);
        float angle = Mathf.Atan2(lookDIR.y, lookDIR.x)*Mathf.Rad2Deg;

        spawnPoint.transform.Rotate(0,0,angle); 

        if (canShoot)
        {
            
                if (time <= 1.5f)
                {
                    time += Time.deltaTime;
                   // animator.SetBool("isShooting", false);

                }
                else if (time >= 1.5f)
                {
                    //animator.SetBool("isShooting", true);
                    time = 0;
                    Shooting();
                }
            }
          

        }
       
    
    void Shooting()
    {
        Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
    }

}
