using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    private static bool stage1flag;
    bool getstage2flag;

    public GameObject cube;

    private AudioSource audioS;
    public AudioClip GetSound;


    void Start()
    {
        audioS = GetComponent<AudioSource>();

        stage1flag = false;
    }

    
    void Update()
    {
        getstage2flag = Stage2.GetStage2Flag();

        if(getstage2flag == true)
        {
            stage1flag = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(GetSound);
            Debug.Log("Stage1クリア");
            stage1flag = true;
            Destroy(GetComponent<BoxCollider>());
            Destroy(cube);
        }
    }


    public static bool GetStage1Flag()
    {
        return stage1flag;
    }
}
