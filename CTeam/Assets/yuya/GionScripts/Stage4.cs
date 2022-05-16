using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4 : MonoBehaviour
{
    private static bool stage4flag;

    public GameObject cube1;

    private AudioSource audioS;
    public AudioClip GetSound;


    void Start()
    {
        audioS = GetComponent<AudioSource>();

        stage4flag = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(GetSound);
            Debug.Log("Stage4クリア");
            stage4flag = true;
            Destroy(GetComponent<BoxCollider>());
            Destroy(cube1);
        }
    }


    public static bool GetStage4Flag()
    {
        return stage4flag;
    }
}
