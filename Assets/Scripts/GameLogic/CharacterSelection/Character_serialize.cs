using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Character
{
   
    public Sprite character_sprite;
    [TextArea(1, 1)]
    public string name;
    [TextArea(5, 5)]
    public string about;
}

public class SerializedCharacter : ScriptableObject
{
    public Character serialized_character;
}

