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

    public void TextManager(string id) // �Ű������� text id �־��ֱ� 
    {
        string textId = id;
        if (FindNextText(textId) == "") return; // ����ִ� text ���� �����̸� �Ѿ

        textPanel.ShowTextPanel(FindNextText(textId));
    }

    public string FindNextText(string id) 
    {
        return textPanel.textData.FindToDataID(id);
    }
}
