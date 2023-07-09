using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   public int mode=0;
    [SerializeField]
    Transform target;

    [SerializeField]
    [Range(0, 100)]
    float speed;

    [SerializeField]
    Rigidbody rb;

    Vector3 dir;
    // [SerializeField]
    // NavMeshAgent enemyAgent;
    GameManager gameManager;

    SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        //enemyAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<CharacterController>().transform;
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.startGame == true)
        {
            //enemyAgent.SetDestination(target.position);
            if (target != null)
            {

                Vector3 moveToTarget = target.position - transform.position;
                dir = new Vector3(moveToTarget.x, moveToTarget.y, transform.position.z);

                if (dir.x < 0)
                {
                    spriteRenderer.flipX = false;
                }
                else if(dir.x > 0)
                {
                    spriteRenderer.flipX = true;

                }
            }


            switch (mode)
            {
                case 0:
                    //Debug.Log("shooting");
                    break;

                case 1:
                   // Debug.Log("reflecting");
                    break;


                default:

                    break;

            }
        }
       
    }

    private void FixedUpdate()
    {
        
            rb.velocity = dir * speed;
            
        
    }
}
