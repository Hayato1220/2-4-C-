using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip Clip1;
    public AudioClip Clip2;

    //入れたオブジェクトを消す
    public GameObject pausePanel;

    //スタートボタンを押したかの判定
    bool pushflag = false;

    private static bool pauseflag;
    //private static bool SEFlag;
    bool getRuleflag;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pausePanel.SetActive(false);    //ポーズ画面を消す
        //SEFlag = true;
        pauseflag = true;
    }

    void Update()
    {
        // Start ボタンが押されたら
        if (Input.GetButton("Start"))
        {

            if (pushflag == true)
            {
                pushflag = false;

                if (Time.timeScale == 1)    //ゲームが動いていたら
                {
                    audioSource.PlayOneShot(Clip2);
                    Time.timeScale = 0;     //ゲーム内の時間を止める
                    pausePanel.SetActive(true); //ポーズ画面を出す

                    //Debug.Log("止まっています");
                }
                else //Time.timeScale = 0だったら
                {
                    audioSource.PlayOneShot(Clip1);
                    Time.timeScale = 1;     //ゲーム内の時間を進める
                    pausePanel.SetActive(false);    //ポーズ画面を消す
                    


                    //Debug.Log("動き出しました");
                }
            }
        }
        else //Startボタンが押されていないときの処理
        {
            pushflag = true;

            //Debug.Log("Startボタンが押されていないとき");
        }
    }

    public static bool GetPauseFlag()
    {
        return pauseflag;
    }
}
