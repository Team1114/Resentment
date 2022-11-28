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
}
