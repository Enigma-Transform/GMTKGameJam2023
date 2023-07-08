using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    [SerializeField]
    int randomInt;

    [SerializeField]
    GameObject[] playerLights;

    [SerializeField]
    GameObject[] enemyLights;

    [SerializeField]
    float time;

    [SerializeField]
    int turn=1;

    [SerializeField]
    int placeHolder = 5;
    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(0, playerLights.Length);

    }

    // Update is called once per frame
    void Update()
    {

        if (time > 0)
        {
            time -= Time.deltaTime;
            if (placeHolder > 0)
            {
                placeHolder--;

            }
        }
        else if(time <= 0)
        {
            randomInt = Random.Range(0,playerLights.Length);
            time = 5;
            placeHolder = 5;
        }
        switch(turn)
        {
            case 0:
                //enemy turn
                break;

            case 1:
                //player turn
                PlayerLightsRandomzied(randomInt);
                break;

            default:
                break;
        }
    }


    void PlayerLightsRandomzied(int randomInt)
    {
        Debug.Log(playerLights[randomInt]);
    }
    void EnemyLightsRandomzied(int randomInt)
    {
        Debug.Log(enemyLights[randomInt]);

    }
}
