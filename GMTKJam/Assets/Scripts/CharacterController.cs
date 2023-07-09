using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Player Movement speed.
    [SerializeField]
    [Range(0,100)]
    float speed;

    [SerializeField]
    [Range(0, 100)]
    float rotationSpeed;


    [SerializeField]
    Projectile projectile;

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    bool spawned;

    float fireRateTime;
   public int powerUpCase;

    [SerializeField]
    int level = 1;
    // Start is called before the first frame update

    [SerializeField]
    int layerIndex;

    [SerializeField]
    GameObject pickedUpObject;

    [SerializeField]
    Rigidbody rb;

    public bool dropsPowerUp;
    bool sizeChangePowerUp;

    public int mode;
    Vector3 scaleProjectile;

    [SerializeField]
    float fireRate;

    PlayerHealthManager playerHealthManager;
    GameManager gameManager;
    SpawnManager spawnManager;

    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager =FindObjectOfType<GameManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
        animator = GetComponent<Animator>();
        playerHealthManager = GetComponent<PlayerHealthManager>();
    }
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("PickUps");

        switch (powerUpCase)
        {
            case 1:
                //powerUp 1 Player Size Increase Speed decrease
                transform.localScale += new Vector3(2, 2, 2);
                speed *=0.7f ;
                break;

            case 2:
                //powerUp 2 Player Size Decrease Speed Increase
                transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                speed *= 1.3f;

                break;
            case 3:
                //powerUp 3 HP gain on breaking mirrors or rocks
                dropsPowerUp = true;
                break;

            case 4:
                //Bullet Damage increases fire rate decreases
                sizeChangePowerUp = true;
                projectile.damage = 5;
                scaleProjectile = new Vector3(4f, 4f, 4f);
                fireRate=0.75f;
                break;
            case 5:
                sizeChangePowerUp = true;
                //Bullet Damage decreases fire rate inscreases.
                projectile.damage = 2;
                scaleProjectile = new Vector3(1f, 1f, 1f);
                fireRate = 0.25f;
                break;
            case 6:
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("playerHealth", playerHealthManager.currentHealth);

        fireRateTime += Time.deltaTime; 
        float nextFireTime = 1 / fireRate;
        MouseAim();

        if (level == 1)
        {
            if (mode == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetBool("isShooting", true);

                  
                        Shooting();
    
                }
                else
                {
                    animator.SetBool("isShooting", false);

                }

            }
            
        }
       
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking",true);
            rb.velocity = transform.up * speed;

        }
       else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            rb.velocity = transform.right * speed;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
            rb.velocity = -transform.right * speed;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);
            rb.velocity = -transform.up * speed;

        }
        else if(powerUpCase!=6)
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("isWalking", false);
        }
    }


    void MouseAim()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - spawnPoint.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        spawnPoint.transform.rotation = rotation;
    }

    void Shooting()
    {
        Debug.Log("Shooting");
        if (sizeChangePowerUp)
        {
            Projectile bullet = Instantiate(projectile, spawnPoint.position, transform.rotation);
            bullet.transform.SetParent(this.gameObject.transform);
            bullet.transform.localScale = scaleProjectile;
        }
        Instantiate(projectile,spawnPoint.position,transform.rotation);
        spawned = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PowerUp")
        {
            powerUpCase= other.GetComponent<PowerUps>().powerUpSelected;
        }

        if (other.gameObject.tag == "Abilitie")
        {
            gameManager.startGame = true;
            StartCoroutine(spawnManager.EnemySpawner());
            Destroy(other.gameObject);
        }
        
    }

    public void HPDROP()
    {
        int randNo = Random.Range(0, 100);

        if (randNo < 50)
        {
            playerHealthManager.currentHealth += 5;
        }

        
    }
}
