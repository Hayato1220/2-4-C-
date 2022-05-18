using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSE : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip hammer;


    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(hammer, 0.3f);
        }
    }
}
