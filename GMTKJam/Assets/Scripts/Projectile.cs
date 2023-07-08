using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    float speed;
    Rigidbody body;

    [SerializeField]
    [Range(0, 100)]
    float damage;
    // Start is called before the first frame update

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shield")
        {
            //  Debug.Log("shield");
            //body.velocity = Vector3.zero;
            Vector3 dir = Vector3.Reflect(body.velocity, collision.contacts[0].normal);
            body.velocity = dir * speed*Time.deltaTime;

        }

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damage);
            Destroy(this.gameObject);

        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
