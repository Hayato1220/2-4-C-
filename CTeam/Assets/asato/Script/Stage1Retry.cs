using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Retry : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("yuyaStage");
    }
    public void OnClickStageRetry()
    {
        SceneManager.LoadScene("asato");
    }
}
