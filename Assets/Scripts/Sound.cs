﻿using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)]
    public float volume;
    [Range(0, 1)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    public bool loop;
    public bool Awake;
}
    


