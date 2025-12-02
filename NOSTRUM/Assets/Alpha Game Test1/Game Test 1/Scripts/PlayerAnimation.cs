using UnityEngine;
using System;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    public void Attack()
    {
        anim.SetBool("IsAttacking", true);
    }

    public void NotAttacking()
    {
        anim.SetBool("IsAttacking", false);
    }
}