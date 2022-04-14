using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseSelect : MonoBehaviour
{
    RectTransform rect;                     //スクリプトが入っているオブジェクトの位置

    static int MenuNumber;                  //ポーズ中のメニューカーソルの位置

    private static bool pushScene = false;  //ポーズ中のメニューから選択したシーンが押されたか管理
    bool pushflag = false;                  //Lスティックがが倒されたかどうか


    public float speed = 1.0f;
    //private float T = 2.0f;
    //private float F = 1.0f / T;
    private float rooptime;

    public AudioSource CursorMove;      //カーソルの選択の音
    public AudioSource CursorCheck;     //カーソルの決定の音

    public Text retry;
    public Text title;
    public Text gameOut;
    bool getpauseflag;

    void Start()
    {
        rect = GetComponent<RectTransform>();   //オブジェクトの位置を取得

        retry = retry.GetComponent<Text>();
        title = title.GetComponent<Text>();
        gameOut = gameOut.GetComponent<Text>();

        MenuNumber = 0;
    }


    void Update()
    {
        getpauseflag = Pause.GetPauseFlag();

        //もし pushScene が false なら
        if(pushScene == false)
        {
            // L_Stick_V が -1（下方向に入力された）の時
            if((!Input.GetButton("B") && Input.GetAxis("L_Stick_V") == -1) || (!Input.GetButton("B") && Input.GetAxis("PadKey_V") == -1))
            {
                if (pushflag == false)      // pushflag が false の時
                {
                    pushflag = true;
                    CursorMove.Play();      //音を鳴らす
                    if (++MenuNumber > 2)    // MenuNumber　を先に1プラスした時に、 ３以上なら
                    {
                        MenuNumber = 0;     //メニューカーソルがリトライの位置に戻る
                    }
                }

            }
            // L_Stick_V が 1（上方向方向に入力された）の時
            else if (!Input.GetButton("B") && Input.GetAxis("L_Stick_V") == 1 || (!Input.GetButton("B") && Input.GetAxis("PadKey_V") == 1))
            {
                if (pushflag == false)
                {
                    pushflag = true;
                    CursorMove.Play();      //音を鳴らす
                    if (--MenuNumber < 0)
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

                    if (Time.timeScale == 0)
                    {
                        retry.color = GetAlphaColor(retry.color);
                    }
                    title.color = ReturnAlphaColor(title.color);
                    gameOut.color = ReturnAlphaColor(gameOut.color);

                    if (Input.GetButton("B")){
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(RetryCoroutine());
                    }
                    break;

                case 1:
                    rect.localPosition = new Vector3(-288, -100, 0);

                    if(Time.timeScale == 0)
                    {
                        title.color = GetAlphaColor(title.color);
                    }
                    retry.color = ReturnAlphaColor(retry.color);
                    gameOut.color = ReturnAlphaColor(gameOut.color);

                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(TitleCoroutine());
                    }
                    break;

                case 2:
                    rect.localPosition = new Vector3(-219, -300, 0);

                    if (Time.timeScale == 0)
                    {
                        gameOut.color = GetAlphaColor(gameOut.color);
                    }
                    retry.color = ReturnAlphaColor(retry.color);
                    title.color = ReturnAlphaColor(title.color);

                    if (Time.timeScale == 1)
                    {
                        gameOut.color = ReturnAlphaColor(gameOut.color);
                    }

                    if (Input.GetButton("B")){
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(EndCoroutine());
                    }
                    break;
            }
        }
    }


    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        if(Time.timeScale == 1)
        {
            rooptime = 0;
        }
        rooptime += speed;
        color.a = Mathf.Sin(rooptime);

        return color;
    }

    //Alpha値を更新してColorを返す(Alpha値を元に戻す）
    Color ReturnAlphaColor(Color color)
    {
        color.a = 255;

        return color;
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
}
