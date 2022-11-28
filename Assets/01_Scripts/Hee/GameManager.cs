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
        Time.timeScale = 1;

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

    bool first = false;

    public void GameOver()
    {
        print("GameOver");
        StartCoroutine(Replay());
    }

    public void GameClear()
    {
        print("GameClear");
        // 다음 스테이지 자동 이동
        StartCoroutine(NextScene());
    }

    IEnumerator Replay()
    {
        if (first) yield break;
        first = true;
        Player.GetComponent<PlayerController>().PlayerStop();
        PlayerAnimation.Instance.Die();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene($"{SceneManager.GetActiveScene().name}");
    }

    IEnumerator NextScene()
    {
        if (first) yield break;
        first = true;
        Player.GetComponent<PlayerController>().PlayerStop();
        yield return new WaitForSeconds(1f);
        string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene($"{int.Parse(sceneName) + 1}");
    }

    public void TimeScaleDownUp()
    {
        StartCoroutine(TimeDown());
    }

    IEnumerator TimeDown()
    {
        while (true)
        {
            Time.timeScale -= 0.1f;
            yield return new WaitForSeconds(0.001f);

            if (Time.timeScale <= 0.2f)
            {
                StartCoroutine(TimeUp());
                StopCoroutine(TimeDown());
                yield break;
            }
        }
    }

    IEnumerator TimeUp()
    {
        while (true)
        {
            Time.timeScale += 0.1f;
            yield return new WaitForSeconds(0.001f);

            if (Time.timeScale >= 0.99f)
            {
                yield break;
            }
        }
    }
}
