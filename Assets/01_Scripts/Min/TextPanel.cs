using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPanel : MonoBehaviour
{
    TextMeshProUGUI _tmp;
    public TextDatas textData;

    Action OnSpaceKeyDown;

    public bool textPanelOn;

    private void Start()
    {
        gameObject.SetActive(false);
        _tmp = GetComponent<TextMeshProUGUI>();
        OnSpaceKeyDown += UnShowTextPanel;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceKeyDown?.Invoke();
        }
    }

    public void ShowTextPanel(string nextText = "")
    {
        if (textPanelOn || nextText == "") return; // 패널이 보여지고 있거나 nextText 값이 공백이면 넘어감

        gameObject.SetActive(true);
        textPanelOn = true;
        _tmp.text = nextText;
    }

    public void UnShowTextPanel()
    {
        if (!textPanelOn) return; // 패널이 보여지고 있지 않으면 넘어감

        textPanelOn = false;
        gameObject.SetActive(false);
    }
}
