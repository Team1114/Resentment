using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    TextMeshProUGUI realText;
    TextDatas textDatas;
    
    private void Awake()
    {
        Instance = this;
        //textDatas = GetComponent<TextDatas>();
        realText = GetComponent<TextMeshProUGUI>();
    }

    public void TextPrint(string text)
    {
        realText.text = text;
    }

}
