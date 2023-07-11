using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
public class Enemy : MonoBehaviour
{
   public int mode=1;
    [SerializeField]
    Transform target;

    AIDestinationSetter destinationSetter;
    AIPath AIPath;
    [SerializeField]
    [Range(0, 100)]
    float speed;

    GameManager gameManager;

    SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
       
        gameManager = FindObjectOfType<GameManager>();
        destinationSetter =GetComponent<AIDestinationSetter>();

        target = FindObjectOfType<CharacterController>().transform;

       // rb = GetComponent<Rigidbody>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        
        destinationSetter.target = target;

    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        }*/

       
    }

    private void FixedUpdate()
    {
        
            
        
    }
}
