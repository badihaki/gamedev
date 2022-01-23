using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewCharacter",menuName ="Player/Player Character")]
public class PlayerCharacter : ScriptableObject
{
    public GameObject playerCharObj;
    public int health;
    public int speed;
}
