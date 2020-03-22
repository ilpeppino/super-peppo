using UnityEngine;

public class PlayerAnimator : MonoBehaviour
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

            case PlayerState.isMoving:
                {
                    _playerAnimator.Play("walk");
                    return;
                }

        }


    }

}
