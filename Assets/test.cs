using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Resentment", 0) == 1)
        {
            PlayerPrefs.SetInt("Resentment", 0);
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            //GetComponent<Rigidbody2D>().angularDrag *= 100;
            GetComponent<Rigidbody2D>().mass = 100;

        }
    }
}
