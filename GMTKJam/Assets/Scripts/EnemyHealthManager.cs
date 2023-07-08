using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField]
    [Range(0,100)]
    int health;

    [SerializeField]
    bool isArmored;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (isArmored == false)
        {
            if (health > 0)
            {
                health -=5;
            }
        }
        else if(isArmored)
        {
            if (health > 0)
            {
                health -= (int)damage;
            }
        }
        
    }
}
