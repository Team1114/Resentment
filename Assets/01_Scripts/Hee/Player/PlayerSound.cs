using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : AudioPlayer
{
    public AudioClip swrodAttack1;
    public AudioClip swrodAttack2;

    public void FirstAttack()
    {
        PlayClip(swrodAttack1);
    }

    public void SecondAttack()
    {
        PlayClip(swrodAttack2);
    }
}
