using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Inspector

    [SerializeField] private float 
        _speed = 7f;

    [SerializeField] private float 
        _jumpForce = 20f;

    #endregion

    #region Cached references

    private PlayerAnimator _playerAnimation;
    private PlayerState _playerState;
    private PlayerAerialState _playerAerialState;
    private Rigidbody _rb;

    #endregion

    #region Local variables

    private Vector3 _movement;    
    private float _input;
    private float _jump;

    private bool _isFacingRight = true;


    #endregion

    private void Awake()
    {
        _playerState = PlayerState.isIdle;
        _playerAerialState = PlayerAerialState.isOnGround;
        _playerAnimation = GetComponent<PlayerAnimator>();
        _rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        MovePlayer();
        JumpPlayer();
        RotatePlayer();
    }

    private void FixedUpdate()
     {

        transform.position += _movement;
        Debug.Log("On ground: " + _playerAerialState + " - State: " + _playerState);
        if (_playerAerialState == PlayerAerialState.isOnGround && _playerState == PlayerState.isJumping)
        {
            _rb.AddForce(_jump * Vector3.up * Time.fixedDeltaTime * _jumpForce, ForceMode.Impulse);
            //_playerAerialState = PlayerAerialState.isInAir;
        } 

    }

    private void MovePlayer()
    {
        _input = Input.GetAxis("Horizontal");

        if (_input != 0f)
        {
            ExecutionAnimation(PlayerState.isWalking);
        } 
        else
        {
            ExecutionAnimation(PlayerState.isIdle);
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
            transform.Rotate(0f, 180f, 0f);
            _isFacingRight = true;
        }

        else if (_input < 0f && _isFacingRight)
        {
            transform.Rotate(0f, -180f, 0f);
            _isFacingRight = false;
        } 

    }

    private void ExecutionAnimation (PlayerState playerState)
    {
        _playerState = playerState;
        _playerAnimation.PlayAnimation(_playerState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Player entered collision with " + collision.gameObject.tag);
            _playerAerialState = PlayerAerialState.isOnGround;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Player exited collision with " + collision.gameObject.tag);
            _playerAerialState = PlayerAerialState.isInAir;
        }

    }


}
