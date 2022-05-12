using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class byunSE : MonoBehaviour
{
    const string SNDNAME = "Sound/byun";

    AudioClip audioClip;

    AudioSource audioSource;

    void Start()
    {
        audioClip = Resources.Load(SNDNAME, typeof(AudioClip)) as AudioClip;
        audioSource = gameObject.AddComponent<AudioSource>();
        //GameObject.DontDestroyOnLoad(this.gameObject);

        audioSource.clip = audioClip;
        audioSource.volume = 1.0f;
        audioSource.Play();
    }
}