using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextData
{
    public string textID;

    [TextArea(3, 7)]
    public string text;
}

[CreateAssetMenu(menuName = "SO/TextDatas")]
public class TextDatas : ScriptableObject
{
    public string ID;
    public List<TextData> textDataList;

    public string FindToDataID(string value = "")
    {
        string str = value;
        foreach (TextData td in textDataList)
        {
            if (Equals(td.textID, str))
            {
                value = td.text;
                break;
            }
            else
            {
                if (!value.Equals(td.text))
                {
                    value = "";
                }
                continue;
            }
        }
        return value;
    }
}
