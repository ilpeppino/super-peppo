using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: walking vs running

public class PlayerMovement : MonoBehaviour
{

    #region Inspector

    [SerializeField]
    private float
        _speed = 7f;

    [SerializeField]
    private float
        _jumpForce = 40f;

    #endregion

    #region Cached references

    private PlayerAnimator _playerAnimator;
    private PlayerState _playerState;
    private PlayerAudioHandler _playerAudioHandler;
    private Rigidbody _rb;

    #endregion

    #region Local variables

    private Vector3 _jump;
    private Vector3 _movement;
    //private float _input;


    private bool _isFacingRight = true;
    private bool _isGrounded = true;


    #endregion

    private void Awake()
    {
        _playerState = PlayerState.isIdle;
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerAudioHandler = GetComponent<PlayerAudioHandler>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
        JumpPlayer();
        RotatePlayer();

        DeterminePlayerState();
        ExecuteAnimation(_playerState);
        PlaySoundEffects(_playerState);

    }

    private void FixedUpdate()
    {

        transform.position += _movement;

        if (_isGrounded) 
            _rb.AddForce(_jump, ForceMode.Impulse);

        Debug.Log("Player grounded: " + _isGrounded);


    }

    private void MovePlayer()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * _speed, 0f, 0f);
    }

    private void JumpPlayer()
    {
        _jump = Input.GetAxis("Jump") * Vector3.up * Time.fixedDeltaTime * _jumpForce;

        Debug.Log("Plsyrt jumping: " + _jump);
    }

    private void RotatePlayer()
    {
        if (_movement.x > 0f && !_isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            _isFacingRight = true;
        }

        else if (_movement.x < 0f && _isFacingRight)
        {
            transform.Rotate(0f, -180f, 0f);
            _isFacingRight = false;
        }

    }

    private void DeterminePlayerState()
    {
        if (_movement.x != 0f)_playerState = PlayerState.isMoving; 
        else _playerState = PlayerState.isIdle;

    }

    private void ExecuteAnimation(PlayerState playerState)
    {
        _playerAnimator.PlayAnimation(_playerState);
    }

    private void PlaySoundEffects(PlayerState playerState)
    {
        _playerAudioHandler.PlayAudio(playerState);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }

    }


}