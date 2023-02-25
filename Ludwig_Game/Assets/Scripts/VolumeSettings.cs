using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        AudioSource audio = GetComponent<AudioSource>();

    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
