using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextPanel textPanel;
    
    private void Awake()
    {
        Instance = this;
    }

    public void TextManager(string id) // 매개변수로 text id 넣어주기 
    {
        string textId = id;
        if (FindNextText(textId) == "") return; // 들어있는 text 값이 공백이면 넘어감

        textPanel.ShowTextPanel(FindNextText(textId));
    }

    public string FindNextText(string id) 
    {
        return textPanel.textData.FindToDataID(id);
    }
}
