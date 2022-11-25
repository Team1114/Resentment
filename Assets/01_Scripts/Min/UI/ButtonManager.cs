using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    InGameESC _inGameESC;

    [Header("Btns")]
    [SerializeField] GameObject startBtn;
    [SerializeField] GameObject settingBtn;
    [SerializeField] GameObject quitBtn;

    [Header("SettingBtns")]
    [SerializeField] GameObject settingMenu;

    [Header("BackGround")]
    [SerializeField] GameObject background;

    [Header("Resolution")]
    [SerializeField] GameObject resolution;

    [Header("Quit")]
    [SerializeField] GameObject QuitQuestion;

    [Header("Start")]
    [SerializeField] GameObject stageSellect;

    [Header("InGameUI")]
    [SerializeField] GameObject InGameUI;

    private void Start()
    {
        _inGameESC = GameObject.Find("InGameEscManager").GetComponent<InGameESC>();
    }

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

    public void InGameQuitQuestionOn()
    {
        QuitQuestion.SetActive(true);
    }

    public void QuitQuestionOff()
    {
        QuitQuestion.SetActive(false);
    }
    #endregion

    #region StageSellect
    public void StageSellectOn()
    {
        stageSellect.SetActive(true );
    }
    public void StageSellectOff()
    {
        stageSellect.SetActive(false);
    }
    #endregion

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void InGameUIOff()
    {
        _inGameESC.escUI.gameObject.SetActive(false);
        Time.timeScale = 1;
        _inGameESC.canUIOn = true;
    }
}
