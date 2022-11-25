using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemySound : AudioPlayer
{
    public AudioClip reload;
    public AudioClip shoot;
    public AudioClip Die;

    bool isReloadPlaying = false;
    bool isShootPlaying = true;

    public void ReloadClipPlay()
    {
        if (isReloadPlaying) return;
        StartCoroutine(ReloadClip());
    }

    IEnumerator ReloadClip()
    {
        isReloadPlaying = true;
        PlayClip(reload);
        yield return null;
    }

    public void ShootClipPlay()
    {
        if (isShootPlaying) return;
        StartCoroutine(ShootClip());
    }

    IEnumerator ShootClip()
    {
        isShootPlaying = true;
        PlayClip(shoot);
        yield return null;
    }

    public void DieClipPlay()
    {
        PlayClip(Die);
    }
}
