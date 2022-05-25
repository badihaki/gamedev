using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dialogue", menuName = "UI/New Dialogue")]
public class Dialogue : ScriptableObject
{
    public Sprite speakerImage;
    public Sprite cinematic;
    public string dialogue;
    public Dialogue nextDialogue;
}
