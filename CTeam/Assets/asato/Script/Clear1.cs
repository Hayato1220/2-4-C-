using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("B"))
        {
            SceneManager.LoadScene("shota");
        }
    }
}