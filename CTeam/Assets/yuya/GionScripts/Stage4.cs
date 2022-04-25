using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4 : MonoBehaviour
{
    private static bool stage4flag;

    void Start()
    {
        stage4flag = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("atari");
            stage4flag = true;
        }
    }


    public static bool GetStage4Flag()
    {
        return stage4flag;
    }
}
