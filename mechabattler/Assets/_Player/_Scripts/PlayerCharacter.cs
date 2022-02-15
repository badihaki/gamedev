using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="NewCharacter",menuName ="Player/Player Character")]
public class PlayerCharacter : ScriptableObject
{
    public GameObject playerCharObj;
    public Sprite characterPortrait;
    public int health;
    public float speed;
    public int maxJumps;
    public float jumpForce;
}
