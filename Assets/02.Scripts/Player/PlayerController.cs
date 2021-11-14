using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;
    private Animator _animator;
    private static readonly int InputX = Animator.StringToHash("InputX");
    private static readonly int InputY = Animator.StringToHash("InputY");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        velocity = new Vector3(inputX, 0f, inputY);
        var offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;
        var isMoving = (velocity.sqrMagnitude != 0 ? true : false);
        
        if (isMoving)
            transform.rotation = Quaternion.LookRotation(velocity);

        if (velocity.sqrMagnitude > 1f)
        {
            _animator.SetBool(IsMoving, isMoving);
            _animator.SetFloat(InputX, (inputX * offset) / Mathf.Sqrt(2));
            _animator.SetFloat(InputY, (inputY * offset) / Mathf.Sqrt(2));
            return;
        }
        
        _animator.SetBool(IsMoving, isMoving);
        _animator.SetFloat(InputX, inputX * offset);
        _animator.SetFloat(InputY, inputY * offset);
    }

}