using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunEnemyController : MonoBehaviour
{
    // 3´Ü°è·Î ³ª´²¼­
    // 1´Ü°è : ´À³¦Ç¥ ¶ç¿ì±â
    // 2´Ü°è : ÃÑ ¹ß»ç ÁØºñ
    // 3´Ü°è : ÃÑ ¹ß»ç

    public GameObject Bullet;

    public float OneStepDistance = 15f;
    public float TwoStepDistance = 10f;
    public float ThreeStepDistance = 5f;

    public UnityEvent OnStepEvent;
    public UnityEvent TwoStepEvent;
    public UnityEvent ThreeStepEvent;

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        print("GunEnemyDie");
    }
}
