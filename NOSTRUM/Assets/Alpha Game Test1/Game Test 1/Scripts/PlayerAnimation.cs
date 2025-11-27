using UnityEngine;
using System;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    public void Attack()
    {
        anim.SetBool("isAttacking", true);
    }
}