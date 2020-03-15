﻿using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Animator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void PlayAnimation (PlayerState playerState)
    {

        switch (playerState)
        {

            case PlayerState.isIdle:
                {
                    _playerAnimator.Play("idle");
                    return;
                }

            case PlayerState.isWalking:
                {
                    _playerAnimator.Play("walk");
                    return;
                }

            case PlayerState.isJumping:
                {
                    return;
                }

        }


    }

}
