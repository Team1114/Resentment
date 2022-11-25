using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : AudioPlayer
{
    public AudioClip Die;

    public void PlayDieClip()
    {
        PlayClip(Die);
    }
}
