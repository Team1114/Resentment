using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextData", menuName = "ScriptableObject/TextData")]
public class TextData : ScriptableObject
{
    [SerializeField]
    private string _textId;
    public string textId { get { return _textId; } }

    [SerializeField]
    private string _text;
    public string text { get { return _text; } } 
}
