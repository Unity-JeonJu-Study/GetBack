using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    
    private Vector3 velocity;
    private Animator _animator;
    private Camera _cam;

    private static readonly int InputX = Animator.StringToHash("InputX");
    private static readonly int InputY = Animator.StringToHash("InputY");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Awake()
    {
        _cam = FindObjectOfType<Camera>();
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

        if (!_animator.GetBool(IsMoving))
        {
            // transform.rotation = _cam.transform.rotation;
        }

        if (isMoving)
            transform.rotation = Quaternion.LookRotation(velocity);

        if (velocity.sqrMagnitude > 1f)
        {
            _animator.SetBool(IsMoving, isMoving);
            _animator.SetFloat(InputX, (inputX * offset) / Mathf.Sqrt(2));
            _animator.SetFloat(InputY, (inputY * offset) / Mathf.Sqrt(2));
        }
        else
        {
            _animator.SetBool(IsMoving, isMoving);
            _animator.SetFloat(InputX, inputX * offset);
            _animator.SetFloat(InputY, inputY * offset);
        }

        if (offset > 0.5f) moveSpeed = 4f;
        else moveSpeed = 2f;
        transform.forward = new Vector3(_cam.transform.forward.x,0f,_cam.transform.forward.z);
        if(isMoving)
        transform.position += transform.forward.normalized * Time.deltaTime * moveSpeed;
    }

    private bool CheckGround()
    {
        RaycastHit hit;
        var centerRay = transform.position +
                        GetComponent<CapsuleCollider>().center;
        Debug.DrawRay(centerRay, Vector3.down, new Color(0.99f, 0.49f, 0.42f), 1.1f);
        if (Physics.Raycast(centerRay, Vector3.down, out hit, 1.1f, LayerMask.GetMask("Ground")))
        {
            return true;
        }

        return false;
    }
}