﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    private static bool stage2flag;
    bool getstage3flag;

    public GameObject cube;

    void Start()
    {
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
            Debug.Log("Stage2クリア");
            stage2flag = true;
            Destroy(cube);
        }
    }


    public static bool GetStage2Flag()
    {
        return stage2flag;
    }
}