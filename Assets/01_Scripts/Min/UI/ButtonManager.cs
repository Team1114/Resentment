using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [Header("Btns")]
    [SerializeField] GameObject contiueBtn;
    [SerializeField] GameObject newGameBtn;
    [SerializeField] GameObject settingBtn;
    [SerializeField] GameObject quitBtn;

    [Header("SettingBtns")]
    [SerializeField] GameObject settingMenu;

    #region SettingBtn
    public void SettingBtnOn()
    {
        settingMenu.SetActive(true);
        //세팅 배경화면 블러
    }
    public void SettingBtnOff()
    {
        settingMenu.SetActive(false);
    }
    #endregion

    #region QuitBtn
    public void QuitButtonOn()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    #endregion
}
