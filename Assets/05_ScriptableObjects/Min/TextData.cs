using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextDatas
{
    public string dataID;

    [TextArea(3,7)]
    public string text;
}

[CreateAssetMenu(fileName = "TextData", menuName = "ScriptableObject/TextData")]
public class TextData : ScriptableObject
{
    [SerializeField]
    private string _textId;
    public string textId { get { return textId; } }

    public List<TextDatas> _list;
}

