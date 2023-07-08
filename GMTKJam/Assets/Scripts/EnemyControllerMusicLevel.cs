using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyControllerMusicLevel : MonoBehaviour
{

    public GameObject musicBox;

    [SerializeField]
    Transform player;
    [SerializeField]
    Rigidbody rb;

    Vector3 dir;

    [SerializeField]
    [Range(0,100)]
    float speed;

    public bool canMove;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<CharacterController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Vector3 moveToTarget = musicBox.transform.position - transform.position;
            dir = new Vector3(moveToTarget.x, moveToTarget.y, transform.position.z);
        }
        else if (!canMove)
        {
            Vector3 moveToPlayer = player.transform.position - transform.position;
            dir = new Vector3(moveToPlayer.x,moveToPlayer.y,transform.position.z);

        }

        
        
    }

    private void FixedUpdate()
    {
        MoveToMusicBlock(canMove);
        ChasePlayer(canMove);
       
    }

    void MoveToMusicBlock(bool canMove)
    {
        if (canMove)
        {
            if (Vector3.Distance(dir, musicBox.transform.position) > 0.1f)
            {
                Vector2 direction = transform.InverseTransformPoint(musicBox.transform.position);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.Rotate(0, 0, angle);
                rb.velocity = dir * speed;

            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        
    }

    void ChasePlayer(bool canMove)
    {
        if (!canMove)
        {
            if (Vector3.Distance(dir,player.position) > 0.5f)
            {
                Vector2 direction = transform.InverseTransformPoint(player.transform.position);
                float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
                transform.Rotate(0,0,angle);
                rb.velocity = dir * speed;

            }
            else
            {
                rb.velocity = Vector3.zero;
  
            }
        }
    }
}
