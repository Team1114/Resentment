using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField]
    private CinemachineVirtualCamera _cmVcam;

    [SerializeField]
    [Range(0, 5f)]
    private float _amplitude = 1, _frequency = 1;

    [SerializeField]
    [Range(0, 1f)]
    private float _duration = 0.1f;

    private CinemachineBasicMultiChannelPerlin _noise;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        _noise = _cmVcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); // Noise 제어
    }

    #region CameraShaking
    public void CameraShake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float time = _duration;
        while (time > 0)
        {
            _noise.m_AmplitudeGain = Mathf.Lerp(0, _amplitude, time / _duration);

            yield return null;
            time -= Time.deltaTime;
        }
        _noise.m_AmplitudeGain = 0; // 진동을 꺼준다.
    }
    #endregion

    public void SizeDown(float changeToSize)
    {
        StartCoroutine(ChangeSize(changeToSize));
    }

    public void SizeUp(float changeToSize)
    {
        StartCoroutine(ChangeSize(changeToSize));
    }

    IEnumerator ChangeSize(float size)
    {
        int sign = 1;
        float currentSize = _cmVcam.m_Lens.OrthographicSize;

        if (size <= currentSize)
        {
            size = -1;
        }
        else
        {
            size = 1;
        }

        while (true)
        {
            if (currentSize <= size & sign == -1)
            {
                yield break;
            }
            else if (currentSize >= size & sign == 1)
            {
                yield break;
            }

            _cmVcam.m_Lens.OrthographicSize += 0.1f * sign;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
