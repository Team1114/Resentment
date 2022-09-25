using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintText : MonoBehaviour
{
    public Ohno o;
    private UIManager uIManager;


    private void Awake()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void Update()
    {
        _PrintText();
    }

    public void _PrintText()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(o.textId == "Ohno")
            {
                uIManager.TextPrint(o.text);
            }
        }
    }
}
