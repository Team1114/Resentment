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
    public Transform bulletPosition;
    public bool isShooting = false;

    public float OneStepDistance = 15f;
    public float TwoStepDistance = 10f;
    public float ThreeStepDistance = 5f;

    public UnityEvent OneStepEvent;
    public UnityEvent TwoStepEvent;
    public UnityEvent ThreeStepEvent;

    public UnityEvent Die;

    private void Update()
    {
        if (!GameManager.Instance.Player.activeSelf) return;
        float distance = Vector2.Distance(transform.position, GameManager.Instance.Player.transform.position);
        if (distance < OneStepDistance && distance > TwoStepDistance)
        {
            print("1");
            OneStepEvent?.Invoke();
        }
        else if (distance < TwoStepDistance && distance > ThreeStepDistance)
        {
            print("2");
            TwoStepEvent?.Invoke();
        }
        else if (distance < ThreeStepDistance)
        {
            print("3");
            ThreeStepEvent?.Invoke();
        }
    }

    public void Shooting()
    {
        if (isShooting) return;
        StartCoroutine(ShootBullet());
    }

    IEnumerator ShootBullet()
    {
        isShooting = true;

        Instantiate(Bullet, bulletPosition.position, Quaternion.identity);

        yield return new WaitForSeconds(0.6f);
    }

    private void OnDisable()
    {
        print("GunEnemyDie");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }

    public void DieMethod()
    {
        Die?.Invoke();  
    }
}
