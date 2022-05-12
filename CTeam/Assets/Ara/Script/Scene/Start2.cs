using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start2 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("B"))
        {
            SceneManager.LoadScene("AraKouStage");
        }
    }
}