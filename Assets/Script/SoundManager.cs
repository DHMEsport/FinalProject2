using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{ 
    private static SoundManager _instance;
    public static SoundManager instance => _instance;

    public static bool hasIntance => _instance != null;
    public enum SoundName
    {
        BGM1,
        hit_enemy,
        jumping,
        death,
        
    }
    [SerializeField] private Sound[] _sounds;
    private void Start()
    {
        Play(SoundName.BGM1);
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Play(SoundName name)
    {
        Sound sound = GetSound(name);
        if (sound.audioSource == null)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
        }

        sound.audioSource.Play();
    }

    private Sound GetSound(SoundName name)
    {
        return Array.Find(_sounds, s => s.soundName == name);
    }
}
