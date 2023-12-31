using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{ Vector2 lastVelocity;
    [SerializeField]
    [Range(0, 100)]
    float speed;
    Rigidbody2D body;

    [Range(0, 100)]
   public int damage;

    CharacterController characterController;
    // Start is called before the first frame update

    private void Awake()
    {
        characterController = FindAnyObjectByType<CharacterController>();
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        body.velocity =  transform.right *speed;
    }

    // Update is called once per frame
    void Update()
    {
        //        transform.Translate(Vector3.right * speed*Time.deltaTime);

        Destroy(this.gameObject, 5f);
    }


    private void LateUpdate()
    {
        lastVelocity = body.velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy");
            if (collision.gameObject.GetComponent<Enemy>().isShieldActive == true)
            {
                transform.Rotate(0, -180, 0);
                body.velocity = transform.right * speed;
                collision.gameObject.GetComponent<Enemy>().shieldHealth -= 1;

            }
            else
            {
                collision.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
                Destroy(this.gameObject);

            }


        }
      

    }

}
    
        

       
  
