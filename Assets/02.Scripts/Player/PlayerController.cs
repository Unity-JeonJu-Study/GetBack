using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float spinSpeed;

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
        if (inputY != 0)
        {
            _animator.SetBool(IsMoving, true);
           // var targetAngle = Mathf.Atan2(0f, inputX)
        }
        else
        {
            _animator.SetBool(IsMoving, false);
        }
        transform.rotation = Quaternion.LookRotation(velocity);
        // if (inputX > 0)
        // {
        //     transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        // }
        //
        // if (inputX < 0)
        // {
        //     transform.Rotate(-Vector3.up * spinSpeed * Time.deltaTime);
        // }
        _animator.SetFloat(InputX, inputX * offset);
        _animator.SetFloat(InputY, inputY * offset);
    }
}
