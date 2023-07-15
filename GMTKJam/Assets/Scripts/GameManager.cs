using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    int switchTime;

    public int playerMode=0,enemyMode=1;
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

    [SerializeField]
    GameObject abilityPanel;
    public bool startGame;

    public int mode=0;

    [SerializeField]
    TextMeshProUGUI timerText;

    [SerializeField]
    Slider slider;

    [SerializeField]
    int round,noOfRounds;
    private void Awake()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        characterController = FindObjectOfType<CharacterController>();
        slider.maxValue = playerHealthManager.health;
        slider.value = slider.maxValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerHealthManager.currentHealth;
        if (round <= noOfRounds)
        {
            if (startGame)
            {
                timerText.text = time.ToString("00");
                abilityPanel.SetActive(false);

                if (playerHealthManager.currentHealth <= 0)
                {
                    GameOver();
                }
                if (time >= switchTime)
                {
                    round += 1;
                    time = 0;

                    if (playerMode == 0 && enemyMode == 1)
                    {
                        playerMode = 1;
                        enemyMode = 0;
                    }
                    else if (playerMode == 1 && enemyMode == 0)
                    {
                        enemyMode = 1;
                        playerMode = 0;
                    }
                }
                else
                {
                    time += Time.deltaTime;
                }
            }

        }
        else if(playerHealthManager.currentHealth>0 &&round>=noOfRounds)
        {
            //SceneManager.LoadScene("MusicLevel");
        }
        
        
    }


    public void GameOver()
    {
        Time.timeScale = 0.05f;
        
            GameOverPane.SetActive(true);
        
    }
}
