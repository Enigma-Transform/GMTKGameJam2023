using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    [SerializeField]
    int randomInt;

    [SerializeField]
    GameObject[] Lights;


    [SerializeField]
    float time;

    [SerializeField]
    int turn=1;

    [SerializeField]
    int placeHolder = 5;

    [SerializeField]
    int counter;

    [SerializeField]
    int holder;
    [SerializeField]
    EnemyControllerMusicLevel[] enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(0, Lights.Length);
        holder = randomInt;
        enemy = FindObjectsOfType<EnemyControllerMusicLevel>();
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
            randomInt = Random.Range(0,Lights.Length);
            holder = randomInt;
            if (counter <6)
            {
                counter++;

            }
            else
            {
                turn = Random.Range(0, 2);
                counter = 0;
            }
            time = 5;
            placeHolder = 5;
        }
        switch(turn)
        {
            case 0:
                //enemy turn
                Lights[randomInt].GetComponent<Renderer>().material.color = Color.red;
               foreach(EnemyControllerMusicLevel E in enemy)
                {
                    if(E.musicBox == Lights[randomInt])
                    {
                        E.canMove = true;
                        break;
                    }
                    else
                    {
                        E.canMove = false;
                        break;
                    }
                }
                break;

            case 1:
                //player turn
                Lights[randomInt].GetComponent<Renderer>().material.color = Color.green;
            
                break;

            default:
                break;
        }
    }

}
