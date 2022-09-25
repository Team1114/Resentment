using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ryeocha", menuName = "ScriptableObject/Ryeocha")]
public class Ryeocha : ScriptableObject
{
    [SerializeField]
    private string _textId;
    public string textId { get { return textId; } }

    [SerializeField]
    private string _text;
    public string text { get { return text; } }
}
