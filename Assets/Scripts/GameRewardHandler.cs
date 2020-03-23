using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameRewardHandler : MonoBehaviour
{

    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private ParticleSystem _coinParticles;
    [SerializeField] private RewardSettings _rewardSettings;
    //[SerializeField] private GameObject _coin;

    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();

        _coinParticles.transform.position = transform.position;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            _coinParticles.Play();
            _animator.Play("CoinWon");
            ScoreHandler.ScorePoints(_rewardSettings.points);
            
        }

    }

    // Event fired once SilverCoinWon animation is finished
    private void DestroyCoin() 
    {
        Destroy(gameObject);
    }


}
