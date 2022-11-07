using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake()
    {
        Instance = this;

        if (Instance == null)
        {
            Debug.Log("Gamanager Instance is null state");
        }
    }
}
