using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nebaSE : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource Asource;

    void Start()
    {
        Asource = GetComponent<AudioSource>();
        //Asource.clip = Resources.Load<AudioClip>(SEfolder);
        
    }

    void Update()
    {
        if (Input.GetButtonDown("A"))
        {
            Debug.Log("ネバネバ");
            Asource.PlayOneShot(sound1);
        }
    }
}
