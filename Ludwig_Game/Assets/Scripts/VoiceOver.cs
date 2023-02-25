using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class VoiceOver : MonoBehaviour
{
    public AudioClip[] voices;
    AudioSource voice;

    void Start()
    {
        voice = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundEvery(1f,4));
    }

    IEnumerator PlaySoundEvery(float t, int times)
    {
        for (int i=0; i < times; i++)
        {
            voice.clip = voices[i];
            voice.Play();
            yield return new WaitForSeconds(t);
        }


    }


}
