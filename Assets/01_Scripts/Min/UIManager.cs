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
    
    private void Awake()
    {
        Instance = this;
        realText = GetComponent<TextMeshProUGUI>();
    }

    public void TextPrint(string text)
    {
        Debug.Log(text);
        realText.text = text;
    }

}
