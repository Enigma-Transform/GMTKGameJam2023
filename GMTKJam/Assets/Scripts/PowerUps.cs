using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    int[] powerUpNo;
    [SerializeField]
    Sprite[] sprits;
    
    public int powerUpSelected;
    // Start is called before the first frame update
    void Start()
    {
        powerUpSelected = Random.Range(0, powerUpNo.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
