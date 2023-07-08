using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float time;
    [SerializeField]
    Enemy enemy;
    [SerializeField]
    CharacterController characterController;
    private void Awake()
    {
        enemy= FindObjectOfType<Enemy>();
        characterController = FindObjectOfType<CharacterController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log("time: " + time);
        if (time >= 30f)
        {
            time = 0;
            if(enemy != null)
            { 
                if (enemy.mode == 0)
                {
                    Debug.Log("Mode: "+enemy.mode);
                    enemy.mode = 1;

                }
                else
                {
                    enemy.mode = 0;
                }
            }
        }
    }
}
