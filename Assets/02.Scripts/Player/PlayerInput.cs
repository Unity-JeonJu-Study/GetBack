using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            if (CheckGround())
            {
                if(player._animator.isMoving)
                {
                }
                _rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
                player._animator.Jump();
            }
                
    }


    private bool CheckGround()
    {
        RaycastHit hit;
        var centerRay = transform.position +
                        GetComponent<CapsuleCollider>().center;
        Debug.DrawRay(centerRay, Vector3.down, new Color(0.99f, 0.49f, 0.42f), 1.1f);
        if (Physics.Raycast(centerRay, Vector3.down, out hit, 1.1f,LayerMask.GetMask("Ground")))
        {
            return true;
        }
        return false;
    }
}
