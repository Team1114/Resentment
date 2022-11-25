using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player;

    private void Awake()
    {
        try
        {
            Instance = this;
            
            if (Instance == null)
            {
                throw new Exception("GameManager Instance is null");
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public void GameOver()
    {
        print("GameOver");
        // Respawn
        SceneManager.LoadScene($"{SceneManager.GetActiveScene().name}");
    }

    public void GameClear()
    {
        print("GameClear");
    }
}
