using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class nebaSE : MonoBehaviour
{
    const string SNDNAME_neba = "Sound/peta";

    AudioClip audioClip_neba;

    AudioSource audioSource_neba;

    void Start()
    {
        audioClip_neba = Resources.Load(SNDNAME_neba, typeof(AudioClip)) as AudioClip;
        audioSource_neba = gameObject.AddComponent<AudioSource>();
        //GameObject.DontDestroyOnLoad(this.gameObject);

        audioSource_neba.clip = audioClip_neba;
        audioSource_neba.volume = 1.0f;
        audioSource_neba.Play();
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
