using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSE : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip Spear;


    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(Spear, 0.3f);
        }
    }
}
