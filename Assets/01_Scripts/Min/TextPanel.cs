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
        if (textPanelOn || nextText == "") return; // �г��� �������� �ְų� nextText ���� �����̸� �Ѿ

        textPanelOn = true;
        _tmp.text = nextText;
        gameObject.SetActive(true);
    }

    public void UnShowTextPanel()
    {
        if (!textPanelOn) return; // �г��� �������� ���� ������ �Ѿ

        textPanelOn = false;
        gameObject.SetActive(false);
    }
}
