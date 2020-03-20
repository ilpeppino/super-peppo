using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRewardHandler : MonoBehaviour
{

    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private ParticleSystem _silverCoinParticles;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("isCoinCaught", false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player gained coin");
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            //_silverCoinParticles.Play();
            _animator.SetBool("isCoinCaught", true);
            //gameObject.SetActive(false);

        }

    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
    }


}
