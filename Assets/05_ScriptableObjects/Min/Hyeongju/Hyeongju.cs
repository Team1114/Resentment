using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hyeongju", menuName = "ScriptableObject/Hyeongju")]
public class Hyeongju : ScriptableObject
{
    [SerializeField]
    private string _textId;
    public string textId { get { return textId; } }

    [SerializeField]
    private string _text;
    public string text { get { return text; } }
}
