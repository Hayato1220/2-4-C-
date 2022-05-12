using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GionBackAra : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("A"))
        {
            SceneManager.LoadScene("shota");
        }
    }
}