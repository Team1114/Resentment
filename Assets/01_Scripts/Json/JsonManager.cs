using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class JsonManager : MonoBehaviour
{
    public static JsonManager instance;
    private string SAVE_PATH = "";
    private string SAVE_FILENAME = "/SaveFile.txt";
    [SerializeField] private JsonData data = null;
    public JsonData Data { get { return data; } }

    #region UI
    public Text intText;
    /*public Text floatText;
    public Text stringText;
    public Text boolText;
    public Image spriteImgae;*/
    #endregion
    private void Start()
    {
        Load();
    }

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    [ContextMenu("불러오기")]
    public void Load()
    {
        Init();
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME) == true)
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            data = JsonUtility.FromJson<JsonData>(json);
        }
    }
    [ContextMenu("저장")]
    public void Save()
    {
        Init();
        print("AA");
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
       
    }
    private void Update()
    {
        DisplayUI();
    }
    public void Init()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        if (Directory.Exists(SAVE_PATH) == false)
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
    }

    public void DisplayUI()
    {
        intText.text = $"Click : {data.clickCount}";
    }
}
