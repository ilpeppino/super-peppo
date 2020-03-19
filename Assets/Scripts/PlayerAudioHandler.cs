using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{

    [System.Serializable] 
    public class PlayerAudioEffects
    {
        public PlayerState playerState;
        public AudioClip audioClip;
    }

    [SerializeField] private List<PlayerAudioEffects> playerAudioClips;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(PlayerState ps)
    {
        foreach (PlayerAudioEffects pae in playerAudioClips)
        {
            if (pae.playerState == ps)
            {             
                _audioSource.clip = pae.audioClip;
                _audioSource.Play();
                return;
            }
        }
    }


    

}
