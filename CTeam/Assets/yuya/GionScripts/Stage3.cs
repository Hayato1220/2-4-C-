using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : MonoBehaviour
{
    private static bool stage3flag;
    bool getstage4flag;

    public GameObject cube;

    private AudioSource audioS;
    public AudioClip GetSound;


    void Start()
    {
        audioS = GetComponent<AudioSource>();

        stage3flag = false;
    }


    void Update()
    {
        getstage4flag = Stage4.GetStage4Flag();

        if (getstage4flag == true)
        {
            stage3flag = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(GetSound);
            Debug.Log("Stage3クリア");
            stage3flag = true;
            Destroy(cube);
        }
    }


    public static bool GetStage3Flag()
    {
        return stage3flag;
    }
}
