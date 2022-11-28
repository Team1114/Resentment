using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #region 카메라 사이즈 크고작게

    /*public void RunSize()
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
    }*/

    #endregion

    [SerializeField]
    private CinemachineVirtualCamera _cmVcam;
    [SerializeField]
    [Range(0, 5f)]
    private float _amplitude = 1, _frequency = 1;
    [SerializeField]
    [Range(0, 1f)]
    private float _duration = 0.1f;

    private CinemachineBasicMultiChannelPerlin _noise;

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
