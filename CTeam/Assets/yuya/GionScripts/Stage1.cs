using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    private static bool stage1flag;
    bool getstage2flag;

    void Start()
    {
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
            Debug.Log("atari");
            stage1flag = true;
        }
    }


    public static bool GetStage1Flag()
    {
        return stage1flag;
    }
}
