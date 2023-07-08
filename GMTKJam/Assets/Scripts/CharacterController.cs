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

    [SerializeField]
    int powerUpCase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (powerUpCase)
        {
            case 1:
                //powerUp 1
                break;

            case 2:
                //powerUp 2
                break;
            case 3:
                //powerUp 3
                break;

            default:
                break;
        }
            


        MouseAim();


        if (Input.GetMouseButtonDown(0))
        {
            
                Shooting();

            
        }
        //Player Movement Inputs
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.right * speed*Time.deltaTime);
        }
        
    }


    void MouseAim()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    void Shooting()
    {
        Instantiate(projectile,spawnPoint.position,transform.rotation);
        spawned = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PowerUp")
        {
            powerUpCase= other.GetComponent<PowerUps>().powerUpSelected;
        }
    }
}
