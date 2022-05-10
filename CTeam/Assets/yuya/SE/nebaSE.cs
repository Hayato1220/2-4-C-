using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class nebaSE : MonoBehaviour
{
    const string SNDNAME_DialBtn = "Sound/peta";

    AudioClip audioClip_DialBtn;

    AudioSource audioSource_DialBtn;

    void Start()
    {
        audioClip_DialBtn = Resources.Load(SNDNAME_DialBtn, typeof(AudioClip)) as AudioClip;
        audioSource_DialBtn = gameObject.AddComponent<AudioSource>();
        //GameObject.DontDestroyOnLoad(this.gameObject);

        audioSource_DialBtn.clip = audioClip_DialBtn;
        audioSource_DialBtn.volume = 1.0f;
        audioSource_DialBtn.Play();
    }

    //void Update()
    //{
    //    if (Input.GetButtonDown("A"))
    //    {
    //        audioSource_DialBtn.clip = audioClip_DialBtn;
    //        audioSource_DialBtn.volume = 1.0f;
    //        audioSource_DialBtn.Play();
    //    }
    //}
}
