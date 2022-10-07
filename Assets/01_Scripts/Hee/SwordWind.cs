using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWind : MonoBehaviour
{
    public bool isRight = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Anayend());
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            transform.position += Vector3.right * 10f * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.position += Vector3.left * 10f * Time.deltaTime; 
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    IEnumerator Anayend()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        transform.position = Vector3.zero;
    }
}
