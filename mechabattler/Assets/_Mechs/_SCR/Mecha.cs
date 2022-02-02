using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Mech",menuName ="Player/Mech")]
public class Mecha : ScriptableObject
{
    [Header("Mech In-Game Obj")]
    public GameObject mechObj;
    [Header("Mech Stats")]
    public int mechHealh;
    public int mechSpeed;
}
