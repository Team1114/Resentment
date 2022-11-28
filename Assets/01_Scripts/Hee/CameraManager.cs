using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    CinemachineVirtualCamera cam;

    private void Awake()
    {
        Instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void RunSize()
    {
        StartCoroutine(SizeChange(7));
    }

    public void JumpSize()
    {
        StartCoroutine(SizeChange(9));
    }

    public void DoubleJumpSize()
    {
        StartCoroutine(SizeChange(11));
    }

    IEnumerator SizeChange(int changeToSize)
    {
        float nowSize = cam.m_Lens.OrthographicSize;
        
        while (true)
        {
            if (nowSize > changeToSize)
            {
                cam.m_Lens.OrthographicSize -= 0.1f;
                if (nowSize <= changeToSize) yield return false;
            }
            else if (nowSize < changeToSize)
            {
                cam.m_Lens.OrthographicSize += 0.1f;
                if (nowSize >= changeToSize) yield return false;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
