using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingObstacle : MonoBehaviour, IObstacleObject
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.color = Color.black;
    }

    public void Crash()
    {
        // nothing
    }
}
