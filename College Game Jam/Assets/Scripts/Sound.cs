using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{

    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;

    [NonSerialized] public AudioSource source;

}
