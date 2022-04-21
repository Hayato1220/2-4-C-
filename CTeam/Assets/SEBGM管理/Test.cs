﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public AudioClip sound1;
    AudioSource audioSource;
    bool pushflag = false;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 左
        if (Input.GetButton("X"))
        {
            if (pushflag == true)
            {
                pushflag = false;
                //音(sound1)を鳴らす
                audioSource.PlayOneShot(sound1);
            }
        }
    }
}