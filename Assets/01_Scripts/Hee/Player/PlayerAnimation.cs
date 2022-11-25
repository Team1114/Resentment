using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;

    Animator anim;

    private void Awake()
    {
        Instance = this; 
        anim = GetComponent<Animator>();
    }

    // Jump : PlayerController ��ũ��Ʈ�� ����
    // Slide : Event
    // Passing : PlayerController ��ũ��Ʈ�� ����
    // Attack : PlayerAttackSystem ��ũ��Ʈ�� ����

    public void JumpAnimOn() 
    {
        anim.SetBool("Jumping", true);
        print("on");
    }

    public void JumpAnimOff()
    {
        anim.SetBool("Jumping", false);
        print("off");
    }

    public void DoubleJumpOn()
    {
        anim.SetBool("DbJumping", true);
    }

    public void DoubleJumpOff()
    {
        anim.SetBool("DbJumping", false);
    }

    public void SlideAnimOn()
    {
        anim.SetBool("Sliding", true);
    }

    public void SlideAnimOff()
    {
        anim.SetBool("Sliding", false);
    }

    public void PassingObjAnimOn() 
    {
        anim.SetBool("Passing", true);
    }

    public void PassingObjAnimOff() 
    {
        anim.SetBool("Passing", false);
    }

    public void FirstAttackAnimOn()
    {
        anim.SetBool("FrAttack", true);
        Invoke("FirstAttackAnimOff", 0.25f);
    }

    public void FirstAttackAnimOff()
    {
        anim.SetBool("FrAttack", false);
    }

    public void SecondAttackAnimOn()
    {
        anim.SetBool("ScAttack", true);
        Invoke("SecondAttackAnimOff", 0.4f);
    }

    public void SecondAttackAnimOff()
    {
        anim.SetBool("ScAttack", false);
    }
}
