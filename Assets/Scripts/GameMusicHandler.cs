using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicHandler : MonoBehaviour
{

    private AudioSource _music;

    private void Awake()
    {
        _music = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (_music == null)
        {
            _music.Play();
            DontDestroyOnLoad(this);
        }
    }

}
