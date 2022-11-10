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

    [Header("BackGround")]
    [SerializeField] GameObject background;

    [Header("Resolution")]
    [SerializeField] GameObject resolution;

    #region SettingBtn
    public void SettingBtnOn()
    {
        settingMenu.SetActive(true);
        background.SetActive(true);
    }
    public void SettingBtnOff()
    {
        settingMenu.SetActive(false);
        background.SetActive(false);
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
