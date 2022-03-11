using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseSelect : MonoBehaviour
{
    RectTransform rect;                     //スクリプトが入っているオブジェクトの位置

    static int MenuNumber = 0;              //ポーズ中のメニューカーソルの位置

    private static bool pushScene = false;  //ポーズ中のメニューから選択したシーンが押されたか管理
    bool pushflag = false;                  //Lスティックがが倒されたかどうか


    void Start()
    {
        rect = GetComponent<RectTransform>();   //オブジェクトの位置を取得
    }


    void Update()
    {
        //もし pushScene が false なら
        if(pushScene == false)
        {
            // L_Stick_V が -1（下方向に入力された）の時
            if(!Input.GetButton("B") && Input.GetAxis("L_Stick_V") == -1)
            {
                if (pushflag == false)      // pushflag が false の時
                {
                    pushflag = true;

                    if(++MenuNumber > 2)    // MenuNumber　を先に1プラスした時に、 ３以上なら
                    {
                        MenuNumber = 0;     //メニューカーソルがリトライの位置に戻る
                    }
                }

            }
            // L_Stick_V が 1（上方向方向に入力された）の時
            else if (!Input.GetButton("B") && Input.GetAxis("L_Stick_V") == 1)
            {
                if (pushflag == false)
                {
                    pushflag = true;

                    if(--MenuNumber < 0)
                    {
                        MenuNumber = 2;
                    }

                }
            }
            else
            {
                pushflag = false;
            }
        }

        if (pushScene == false)
        {
            switch (MenuNumber)
            {
                case 0:
                    rect.localPosition = new Vector3(-187, 110, 0);
                    if(Input.GetButton("B")){
                        pushScene = true;
                        StartCoroutine(RetryCoroutine());
                    }
                    break;
                case 1:
                    rect.localPosition = new Vector3(-288, -100, 0);
                    if (Input.GetButton("B"))
                    {
                        pushScene = true;
                        StartCoroutine(TitleCoroutine());
                    }
                    break;
                case 2:
                    rect.localPosition = new Vector3(-219, -300, 0);
                    if(Input.GetButton("B")){
                        pushScene = true;
                        StartCoroutine(EndCoroutine());
                    }
                    break;
            }
        }
    }



    private IEnumerator RetryCoroutine()    //StageNumberによってロードシーンを管理
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("Stage1Ara");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator TitleCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("shota");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator EndCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Application.Quit();
    }


    public static bool PushLoadScene()
    {
        return pushScene;
    }

    public static bool GetPushScene()
    {
        return pushScene;
    }
}
