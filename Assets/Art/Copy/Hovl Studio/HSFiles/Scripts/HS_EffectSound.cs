﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS_EffectSound : MonoBehaviour
{
    public bool Repeating = true;
    public float RepeatTime = 2.0f;
    public float StartTime = 0.0f;
    public bool RandomVolume = true;
    public float minVolume = .4f;
    public float maxVolume = 1f;
    private AudioClip clip;
    private AudioSource soundComponent;
    private void OnEnable()
    {
        soundComponent = GetComponent<AudioSource>();
        clip = soundComponent.clip;
        if (RandomVolume == true)
        {
            soundComponent.volume = Random.Range(minVolume, maxVolume);
            RepeatSound();
        }
        if (Repeating == true)
        {
            InvokeRepeating("RepeatSound", StartTime, RepeatTime);
        }
    }

    void RepeatSound()
    {
        soundComponent.PlayOneShot(clip);
    }
}
