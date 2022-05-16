using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class byunSE : MonoBehaviour
{
    const string SNDNAME = "Sound/byun";

    AudioClip audioClip;

    AudioSource audioSource_byun;

    void Start()
    {
        audioClip = Resources.Load(SNDNAME, typeof(AudioClip)) as AudioClip;
        audioSource_byun = gameObject.AddComponent<AudioSource>();
        //GameObject.DontDestroyOnLoad(this.gameObject);

        audioSource_byun.clip = audioClip;
        audioSource_byun.volume = 1.0f;
        audioSource_byun.Play();
    }
}