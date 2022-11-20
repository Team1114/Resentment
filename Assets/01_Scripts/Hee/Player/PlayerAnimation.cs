using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void RunAnimation()
    {

    }

    public void JumpAnimation() // 2단점프까지 있음
    {

    }

    public void SlideAnimation()
    {

    }

    public void PassingObjAnimation() // 랜덤으로 2개 중에 하나 실행
    {

    }

    public void FirstAttackAnimation()
    {

    }

    public void SecondAttackAnimation()
    {

    }
}
