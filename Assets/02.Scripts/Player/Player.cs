using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region FunctionClass Reference
    
    [HideInInspector] public PlayerController _controller;
    [HideInInspector] public PlayerInput _input;
    [HideInInspector] public PlayerAnimator _animator;

    #endregion

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<PlayerAnimator>();
    }
}
