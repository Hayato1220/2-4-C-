using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4 : MonoBehaviour
{
    private static bool stage4flag;

    public GameObject cube1;
    public GameObject cube2;

    void Start()
    {
        stage4flag = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Stage4クリア");
            stage4flag = true;
            Destroy(cube1);
            Destroy(cube2);
        }
    }


    public static bool GetStage4Flag()
    {
        return stage4flag;
    }
}
