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
        _jumpForce = 40f;

    #endregion

    #region Cached references

    private PlayerAnimator _playerAnimator;
    private PlayerState _playerState;
    private PlayerAerialState _playerAerialState;
    private PlayerAudioHandler _playerAudioHandler;
    private GameObject _iceAttack;
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
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerAudioHandler = GetComponent<PlayerAudioHandler>();
        _rb = GetComponent<Rigidbody>();

        Debug.Log(_iceAttack);

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
            ExecuteAnimation(PlayerState.isWalking);
            _playerAudioHandler.PlayAudio(PlayerState.isWalking);
        } 
        else
        {
            ExecuteAnimation(PlayerState.isIdle);
        }

        _movement = new Vector3(_input * Time.fixedDeltaTime * _speed, 0f, 0f);
    }

    private void JumpPlayer()
    {

        _jump = Input.GetAxis("Jump");

        if (_jump != 0f)
        {
            ExecuteAnimation(PlayerState.isJumping);
        }
        else if (_jump == 0f && (_playerState == PlayerState.isJumping))
        {
            ExecuteAnimation(PlayerState.isWalking);
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



    private void ExecuteAnimation (PlayerState playerState)
    {
        _playerState = playerState;
        _playerAnimator.PlayAnimation(_playerState);
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
