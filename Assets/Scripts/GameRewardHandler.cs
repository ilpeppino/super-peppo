using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameRewardHandler : MonoBehaviour
{

    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private ParticleSystem _silverCoinParticles;
    [SerializeField] private RewardSettings _rewardSettings;

    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            _silverCoinParticles.Play();
            _animator.Play("SilverCoinWon");
            ScoreHandler.ScorePoints(_rewardSettings.points);
            
        }

    }

    // Event fired once SilverCoinWon animation is finished
    private void DestroyCoin() 
    {
        Destroy(gameObject);
    }


}
