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
        //_animator.SetBool("isCoinCaught", false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            _silverCoinParticles.Play();
            _animator.Play("SilverCoinWon");
            //_animator.SetBool("isCoinCaught", true);
            ScoreHandler.ScorePoints(_rewardSettings.points);
            
        }

    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
    }


}
