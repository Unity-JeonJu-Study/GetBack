using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Player player;
    private Animator animator;
    private static readonly int Jump1 = Animator.StringToHash("Jump");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Awake()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
    }

    public bool isMoving => animator.GetBool(IsMoving);

    public void Jump()
    {
        SetJumpTrigger();
    }
    private void SetJumpTrigger()
    {
        animator.SetTrigger(Jump1);
    }
    
}
