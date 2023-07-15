using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    public int abilityNo;
    [SerializeField]
    SpawnManager spawnManager;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    GameObject abilityPanel;
    private void Awake()
    {
        spawnManager =GameObject.FindObjectOfType<SpawnManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
     
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void onClick()
    {
        abilityPanel.SetActive(false);
        gameManager.startGame = true;

        Debug.Log(abilityNo);
    }
}
