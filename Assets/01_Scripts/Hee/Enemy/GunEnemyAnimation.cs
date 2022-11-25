using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemyAnimation : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OneStepOn()
    {
        anim.SetBool("OneStep", true);
    }

    public void OneSteopOff()
    {
        anim.SetBool("OneStep", false);
    }

    public void TwoStepOn()
    {
        anim.SetBool("TwoStep", true);
    }

    public void TwoSteopOff()
    {
        anim.SetBool("TwoStep", false);
    }

    public void ThreeStepOn()
    {
        anim.SetBool("ThreeStep", true);
    }

    public void ThreeSteopOff()
    {
        anim.SetBool("ThreeStep", false);
    }
}
