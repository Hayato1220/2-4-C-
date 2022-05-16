using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeSE : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip blade;


    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(blade, 0.3f);
        }
    }
}
