using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Test : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cinemachine;
    void Start()
    {
        PlusCam();
    }

    public void PlusCam()
    {
        Debug.Log("3122");
        cinemachine.m_Lens.OrthographicSize = 10;
    }
}
