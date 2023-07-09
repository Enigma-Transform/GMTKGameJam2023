using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class LightController : MonoBehaviour
{

    [SerializeField]
    int randomInt;

    [SerializeField]
    GameObject[] Lights;


    [SerializeField]
    float time;

    [SerializeField]
    int turn = 1;

    [SerializeField]
    int placeHolder = 5;

    [SerializeField]
    int counter;

   

 
    [SerializeField]
    List<int> musicBoxOrder = new List<int> { 1, 2, 3, 4, 5, };

    int lightCounter;
    // Start is called before the first frame update
    void Start()
    {
  

        musicBoxOrder = musicBoxOrder.OrderBy(i => Guid.NewGuid()).ToList();

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
            
             if (counter <6)
             {
                 counter++;

             }
             else
             {
                 turn = UnityEngine.Random.Range(0, 2);
                 counter = 0;
             }
             time = 5;
             placeHolder = 5;
            if(lightCounter<=musicBoxOrder.Count)
            {
                lightCounter++;

            }
        }
        switch(turn)
        {
            case 0:
                //enemy turn
                Lights[lightCounter].GetComponent<Renderer>().material.color = Color.red;
              
                break;

            case 1:
                //player turn
                Lights[lightCounter].GetComponent<Renderer>().material.color = Color.green;
            
                break;

            default:
                break;
        }
    }
        
}
