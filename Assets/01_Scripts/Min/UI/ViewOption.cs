using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewOption : MonoBehaviour
{
    FullScreenMode screenMode = FullScreenMode.FullScreenWindow;
    public Toggle fullScreenBtn;
    public Toggle screenBtn;


    private void Start()
    {
        Screen.SetResolution(1920, 1080, screenMode);
        InitUI();
    }

    void InitUI()
    {
        fullScreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void OKButtonClick()
    {
        Screen.SetResolution(Screen.width, Screen.height, screenMode);
    }

    public void FullBtn()
    {
        screenMode = FullScreenMode.FullScreenWindow;
    }
    public void ScreenBtn()
    {
        screenMode = FullScreenMode.Windowed;
    }

}
