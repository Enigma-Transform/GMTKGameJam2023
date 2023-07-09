using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float time;
    [SerializeField]
    List<Enemy> enemy;
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    PlayerHealthManager playerHealthManager;
    [SerializeField]
    GameObject GameOverPane;

    public bool startGame;
    private void Awake()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        characterController = FindObjectOfType<CharacterController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        enemy = FindObjectsOfType<Enemy>().ToList<Enemy>();

        if (playerHealthManager.currentHealth <= 0)
        {
            GameOver();
        }
            time += Time.deltaTime;
        //Debug.Log("time: " + time);
        if (time >= 30f)
        {
            time = 0;
            if(enemy != null)
            { 
                foreach(Enemy enemy in enemy)
                {
                    if (enemy.mode == 0)
                    {
                        // Debug.Log("Mode: "+enemy.mode);
                        enemy.mode = 1;

                    }
                    else
                    {
                        enemy.mode = 0;
                    }
                }
               
            }

            characterController.mode = 1;
        }
    }


    public void GameOver()
    {
        Time.timeScale = 0.05f;
        
            GameOverPane.SetActive(true);
        
    }
}
