using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Cached references

    private PlayerAnimation _playerAnimation;
    private PlayerState _playerState;
    private Rigidbody _rb;

    #endregion

    #region Local variables

    private Vector3 _movement;
    private float _speed;
    private float _jumpForce;
    private float _input;
    private float _jump;
    private bool _isFacingRight; // 1 = facing right, -1 = facing left
    private bool _isOnGround;

    #endregion

    private void Awake()
    {
        _playerState = PlayerState.isIdle;
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rb = GetComponent<Rigidbody>();

        _speed = 3f;
        _isFacingRight = true;
        _isOnGround = true;
        _jumpForce = 25f;
    }


    private void Update()
    {
        MovePlayer();
        JumpPlayer();
        RotatePlayer();
        AnimatePlayer();
    }

    private void FixedUpdate()
     {

        transform.position += _movement;
        Debug.Log("On ground: " + _isOnGround + " - State: " + _playerState);
        if (_isOnGround && _playerState == PlayerState.isJumping)
        {
            _rb.AddForce(_jump * Vector3.up * Time.fixedDeltaTime * _jumpForce, ForceMode.Impulse);
            Debug.Log("AddForce is on ");
        } 
        else 
            Debug.Log("AddForce is off");

    }


    private void MovePlayer()
    {
        _input = Input.GetAxis("Horizontal");

        if (_input != 0f)
        {
            ExecutionAnimation(PlayerState.isWalking);
        }

        _movement = new Vector3(_input * Time.fixedDeltaTime * _speed, 0f, 0f);
    }


    private void JumpPlayer()
    {

        _jump = Input.GetAxis("Jump");

        if (_jump != 0f)
        {
            ExecutionAnimation(PlayerState.isJumping);
        }
        else if (_jump == 0f && (_playerState == PlayerState.isJumping))
        {
            ExecutionAnimation(PlayerState.isWalking);
        }
    }


    private void RotatePlayer()
    {
        if (_input > 0f && !_isFacingRight)
        {
            Debug.Log("Turning left");
            transform.Rotate(0f, 180f, 0f);
            _isFacingRight = true;
        }

        else if (_input < 0f && _isFacingRight)
        {
            Debug.Log("Turning right");
            transform.Rotate(0f, -180f, 0f);
            _isFacingRight = false;
        } 

    }

    private void AnimatePlayer()
    {

/*        if (_input > Mathf.Epsilon || _input < -Mathf.Epsilon)
        {
            ExecutionAnimation(PlayerState.isWalking);  
        }
        else
        {
            ExecutionAnimation(PlayerState.isIdle);
        }*/
    }


    private void ExecutionAnimation (PlayerState playerState)
    {
        _playerState = playerState;
        _playerAnimation.PlayAnimation(_playerState);
        Debug.Log(_playerState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Player entered collision with " + collision.gameObject.tag);
            _isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Player exited collision with " + collision.gameObject.tag);
            _isOnGround = false;
        }
        
    }

}
