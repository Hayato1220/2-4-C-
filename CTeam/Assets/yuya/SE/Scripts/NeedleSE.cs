using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleSE : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip Needle;


    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(Needle, 0.3f);
        }
    }
}
