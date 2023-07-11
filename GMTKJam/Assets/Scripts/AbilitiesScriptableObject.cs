using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Ability Scriptable Object",menuName ="ScriptableObjects/Abilites")]
public class AbilitiesScriptableObject : ScriptableObject
{
    public int abilityNumber;
    public Sprite abilitySprite;
}
