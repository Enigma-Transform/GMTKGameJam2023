using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
public class Enemy : MonoBehaviour
{
   public int mode=0;
    [SerializeField]
    Transform target;

    AIDestinationSetter destinationSetter;
    AIPath AIpath;
    [SerializeField]
    [Range(0, 100)]
    float speed;

    GameManager gameManager;

    SpriteRenderer spriteRenderer;
    EnemyShooting shooting;
    Transform shield;
    public GameObject shieldGO;
  public  bool isShieldActive;

    public int shieldHealth;
    private void Awake()
    {
        shooting = GetComponent<EnemyShooting>();
       AIpath =  GetComponent<AIPath>();
        gameManager = FindObjectOfType<GameManager>();
        destinationSetter =GetComponent<AIDestinationSetter>();

        target = FindObjectOfType<CharacterController>().transform;

       // rb = GetComponent<Rigidbody>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        

    }
    void Start()
    {
        mode = gameManager.enemyMode;

    }

    // Update is called once per frame
    void Update()
    {
        mode = gameManager.enemyMode;


        if (gameManager.startGame == true)
        {
            if (shieldHealth <= 0)
            {
                shieldGO.SetActive(false);
                isShieldActive = false;
                shieldHealth = 0;
            }


            switch (mode)
            {
                case 0:
                    //Debug.Log("shooting");
                    AIpath.canMove = true;
                    shooting.canShoot = true;
                    if (isShieldActive)
                    {
                        isShieldActive = false;
                        shieldGO.SetActive(false );
                    }
                    destinationSetter.target = target;
                    break;

                case 1:
                    shooting.canShoot = false;

                    if (isShieldActive == false)
                    {
                        if (shield == null)
                        {
                            shield = GameObject.FindGameObjectWithTag("Mirror").transform;

                        }
                        if (shield != null)
                        {
                            destinationSetter.target = shield;

                        }
                    }
                   
                    if (isShieldActive)
                    {
                        AIpath.canMove = false;
                    }
                    //AIpath.canMove = false;
                    break;


                default:

                    break;

            }
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Mirror")
        {
            Debug.Log("Mirror, Mode: 0");
            if(mode== 1)
            {
                Debug.Log("Mirror, Mode: 1");

                isShieldActive = true;
                shieldHealth = 3;
                shieldGO.SetActive(true);
                Destroy(collision.gameObject);
            }
            
        }
    }
}
