using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class AbilityPanel : MonoBehaviour
{
 
    // Start is called before the first frame update
    [SerializeField]
    List<AbilitiesScriptableObject> m_Abilites;
    [SerializeField]
    GameObject m_abilityPrefabs;

    public GameObject[] abilityPrefab;
    // Start is called before the first frame update
    void Start()
    {
        List<AbilitiesScriptableObject> abilityNo = m_Abilites.OrderBy(i => Guid.NewGuid()).ToList();


        for (int j = 0; j <= abilityPrefab.Length-1; j++)
        {
            abilityPrefab[j].GetComponent<Image>().sprite = abilityNo[j].abilitySprite;
            abilityPrefab[j].GetComponent<AbilityButton>().abilityNo = abilityNo[j].abilityNumber;
            // GameObject abilities=  Instantiate(abilityPrefab, new Vector3(j*2.9f , transform.position.y, transform.position.z), Quaternion.identity);
            //abilities.transform.SetParent(this.transform);
        }
            // Make the objects collidable.
        
       
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
