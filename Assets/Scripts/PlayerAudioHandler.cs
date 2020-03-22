using System.Collections.Generic;
using UnityEngine;

// It handles the player audio clip depending on the player state

public class PlayerAudioHandler : MonoBehaviour
{

    // Mapping audio clips to player state

    [System.Serializable] public class PlayerAudioEffects
    {
        public PlayerState playerState;
        public AudioClip audioClip;
    }
    [SerializeField] private List<PlayerAudioEffects> playerAudioClips;


    #region Cached reference

    private AudioSource _audioSource;

    #endregion 

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 1;
    }


    // Play audio clip based on player state
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

        _audioSource.Stop();
    }


    

}
