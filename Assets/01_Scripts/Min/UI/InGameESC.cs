using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameESC : MonoBehaviour
{

    public GameObject escUI;
    public bool canUIOn = true;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(canUIOn)
            {
                Debug.Log("321");
                canUIOn = false;
                escUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
