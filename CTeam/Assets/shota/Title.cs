using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    public void sube()
    {
        SceneManager.LoadScene("yuyaStage");
    }
    public void suke()
    {
        SceneManager.LoadScene("asato");
    }
}