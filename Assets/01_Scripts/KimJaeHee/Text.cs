using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Text : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    string testString = "asbsa";

    // Start is called before the first frame update
    void Start()
    {
        TextPopUp(testString);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TextPopUp(string sentence)
    {

        char[] arr = sentence.ToCharArray();

        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Log(i);
            text.text += arr[i];
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.1f);
    }
}
