using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    public int health;

    [SerializeField]
    GameObject destoryedMirror;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
           // Instantiate(destoryedMirror,transform.position, Quaternion.identity);
        }
    }

   public void TakeDamage(int damage)
    {
        if(health > 0)
        {
            health -= damage;
        }
       
    }
   
}
