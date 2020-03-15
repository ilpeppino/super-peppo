using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Cached references

    private PlayerAnimation _playerAnimation;
    private PlayerState _playerState;

    #endregion

    #region Local variables

    private Vector3 _movement;
    private float _speed;
    private float _input;
    private bool _isFacingRight; // 1 = facing right, -1 = facing left

    #endregion

    private void Awake()
    {
        _playerState = PlayerState.isIdle;
        _playerAnimation = GetComponent<PlayerAnimation>();

        _speed = 3f;
        _isFacingRight = true;
    }

    private void FixedUpdate()
    {

        transform.position += _movement;
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayer();
        AnimatePlayer();
    }

    private void MovePlayer()
    {
        _input = Input.GetAxis("Horizontal");
        _movement = new Vector3(_input * Time.fixedDeltaTime * _speed, 0f, 0f);
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

        if (_input > Mathf.Epsilon || _input < -Mathf.Epsilon)
        {
            _playerState = PlayerState.isWalking;
            _playerAnimation.PlayAnimation(_playerState);
        }
        else
        {
            _playerState = PlayerState.isIdle;
            _playerAnimation.PlayAnimation(_playerState);
        }
    }

}
