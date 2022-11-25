using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{ 
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    public List<Image> Imagelist = new List<Image>();

    public int listCount = 0;

    private void Start()
    {
        for(int i = 0; i < Imagelist.Count; i++)
        {
            Imagelist[i] = Imagelist[i].GetComponent<Image>();
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(listCount != 0)
            {
                Imagelist[listCount - 1].gameObject.SetActive(false);
            }
            if (Imagelist.Count == listCount)
            {
                for (int i = 0; i < Imagelist.Count; i++)
                {
                    Imagelist[i].gameObject.SetActive(false);
                }
            }
            else
            {
                if(listCount < Imagelist.Count)
                {
                    listCount++;
                    StartCoroutine(Fade(0, 1));
                }
            }
            
        }
    }

    IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while ( percent < 1 )
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = Imagelist[listCount-1].color;
            color.a = Mathf.Lerp(start, end, percent);
            Imagelist[listCount-1].color = color;

            yield return null;
        }
    }
}
