using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRewardHandler : MonoBehaviour
{

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player gained coin");
            _audio.Play();
            Destroy(gameObject, 1f);
        }

    }

}
