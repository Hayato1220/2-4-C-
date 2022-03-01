using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageRetry99 : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("asato");
    }
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("shota");
    }
}
