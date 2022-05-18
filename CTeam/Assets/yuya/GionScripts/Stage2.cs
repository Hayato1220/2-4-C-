using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    private static bool stage2flag;
    bool getstage3flag;

    public GameObject cube;

    private AudioSource audioS;
    public AudioClip GetSound;


    void Start()
    {
        audioS = GetComponent<AudioSource>();

        stage2flag = false;
    }


    void Update()
    {
        getstage3flag = Stage3.GetStage3Flag();

        if (getstage3flag == true)
        {
            stage2flag = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(GetSound);
            Debug.Log("Stage2クリア");
            stage2flag = true;
            Destroy(GetComponent<BoxCollider>());
            Destroy(cube);
        }
    }


    public static bool GetStage2Flag()
    {
        return stage2flag;
    }
}
