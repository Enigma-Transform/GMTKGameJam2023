using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Vector2 lastVelocity;
    [SerializeField]
    [Range(0, 100)]
    float speed;
    Rigidbody2D body;

    [Range(0, 100)]
    public int damage;

    CharacterController characterController;

    private void Awake()
    {
        characterController = FindAnyObjectByType<CharacterController>();
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right * speed;


    }

    // Update is called once per frame
    private void Update()
    {
        Destroy(this.gameObject, 5f);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (characterController.shieldActive == true)
            {
                transform.Rotate(0, -180, 0);
                body.velocity = transform.right * speed;
                characterController.shieldHealth -= 1;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
                Debug.Log("player");
                Destroy(this.gameObject);
            }


        }
        
    }

}
