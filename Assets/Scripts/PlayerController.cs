﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 public float gravity = 9.8f;

 private float _fallVelocity = 0;

 public float jumpForce;

 private CharacterController _characterController;

 public float speed;

 private Vector3 _moveVector;

 public Animator animator;
   
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
      MovementUpdate();

      JumpUpdate();
    }


    private void MovementUpdate()
    {

      _moveVector = Vector3.zero;

      var runDirection = 0;

      if (Input.GetKey(KeyCode.W))
      {
        _moveVector += transform.forward;

        runDirection = 1;
      }

      if (Input.GetKey(KeyCode.A))
      {
        _moveVector -= transform.right;

        runDirection = 4;
      }

      if (Input.GetKey(KeyCode.S))
      {
        _moveVector -= transform.forward;

        runDirection = 2;
      }

      if (Input.GetKey(KeyCode.D))
      {
        _moveVector += transform.right;

        runDirection = 3;
      }

      animator.SetInteger("Run Direction", runDirection);
    }
    

    private void JumpUpdate()

    {
     if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
      {
        _fallVelocity = - jumpForce;
      }
    }
   
    void FixedUpdate()
    {
    _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
    _fallVelocity += gravity * Time.fixedDeltaTime;
       _characterController.Move(Vector3.down * _fallVelocity * Time.deltaTime);

       if (_characterController.isGrounded)
       _fallVelocity = 0;
    }
 }