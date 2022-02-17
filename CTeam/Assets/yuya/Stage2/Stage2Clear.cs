using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2Clear : MonoBehaviour
{
    public GameObject cleartext;

    void Start()
    {
        cleartext.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cleartext.SetActive(true);
        }
    }
}
