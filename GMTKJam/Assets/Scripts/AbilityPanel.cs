using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
using UnityEngine;
using System;

public class AbilityPanel : MonoBehaviour
{
 
    // Start is called before the first frame update
    [SerializeField]
    List<AbilitiesScriptableObject> m_Abilites;
    [SerializeField]
    GameObject m_abilityPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        List<AbilitiesScriptableObject> abilityNo = m_Abilites.OrderBy(i => Guid.NewGuid()).ToList();


        for (int j = 0; j <= 2; j++)
        {
             m_abilityPrefabs.GetComponent<SpriteRenderer>().sprite = abilityNo[j].abilitySprite;
            Instantiate(m_abilityPrefabs, new Vector3(j*2.9f , transform.position.y, transform.position.z), Quaternion.identity);
        }
            // Make the objects collidable.
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
