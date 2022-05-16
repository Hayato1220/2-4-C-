using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSentakuAra : MonoBehaviour
{
    RectTransform rect;                     //スクリプトが入っているオブジェクトの位置

    static int MenuNumber;                  //ポーズ中のメニューカーソルの位置

    public bool pushScene;  //ポーズ中のメニューから選択したシーンが押されたか管理
    bool pushflag = false;                  //Lスティックがが倒されたかどうか


    public float speed = 1.0f;
    //private float T = 2.0f;
    //private float F = 1.0f / T;
    private float rooptime;

    public AudioSource CursorMove;      //カーソルの選択の音
    public AudioSource CursorCheck;     //カーソルの決定の音

    public Text start;
    public Text sousa;
    public Text gion;
    public Text end;


    bool getpauseflag;

    void Start()
    {
        rect = GetComponent<RectTransform>();   //オブジェクトの位置を取得

        start = start.GetComponent<Text>();
        sousa = sousa.GetComponent<Text>();
        gion = gion.GetComponent<Text>();
        end = end.GetComponent<Text>();


        MenuNumber = 0;

        pushScene = false;
    }


    void Update()
    {
        //もし pushScene が false なら
        if (pushScene == false)
        {
            // L_Stick_V が -1（下方向に入力された）の時
            if ((!Input.GetButton("B") && Input.GetAxis("L_Stick_V") == -1) || (!Input.GetButton("B") && Input.GetAxis("PadKey_V") == -1))
            {
                if (pushflag == false)      // pushflag が false の時
                {

                    pushflag = true;
                    CursorMove.Play();      //音を鳴らす

                    if(MenuNumber == 0)
                    {
                        MenuNumber = 2;
                    }
                    else if (MenuNumber == 2)    
                    {
                        MenuNumber = 0;     
                    }
                    else if(MenuNumber == 1)
                    {
                        MenuNumber = 3;
                    }
                    else if (MenuNumber == 3)
                    {
                        MenuNumber = 1;
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
                    if (MenuNumber  == 2)
                    {
                        MenuNumber = 0;
                    }
                    else if (MenuNumber == 0)
                    {
                        MenuNumber = 2;
                    }
                    else if (MenuNumber == 1)
                    {
                        MenuNumber = 3;
                    }
                    else if (MenuNumber == 3)
                    {
                        MenuNumber = 1;
                    }
                }
            }
            else if (!Input.GetButton("B") && Input.GetAxis("L_Stick_H") == 1)
            {
                if (pushflag == false)      // pushflag が false の時
                {
                    pushflag = true;
                    CursorMove.Play();
                    if (MenuNumber == 0)
                    {
                        MenuNumber = 1;
                    }
                    else if (MenuNumber == 2)
                    {
                        MenuNumber = 3;
                    }
                }
            }
            else if (!Input.GetButton("B") && Input.GetAxis("L_Stick_H") == -1)
            {
                if (pushflag == false)      // pushflag が false の時
                {
                    pushflag = true;
                    CursorMove.Play();
                    if (MenuNumber == 1)
                    {
                        MenuNumber = 0;
                    }
                    else if (MenuNumber == 3)
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
                    rect.localPosition = new Vector3(-360, -50, 0);

                    if (Time.timeScale == 0)
                    {
                        start.color = GetAlphaColor(start.color);
                    }
                    sousa.color = ReturnAlphaColor(sousa.color);
                    gion.color = ReturnAlphaColor(gion.color);
                    end.color = ReturnAlphaColor(end.color);


                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(StartCoroutine());
                    }
                    break;

                case 1:
                    rect.localPosition = new Vector3(100, -50, 0);

                    if (Time.timeScale == 0)
                    {
                        sousa.color = GetAlphaColor(sousa.color);
                    }
                    start.color = ReturnAlphaColor(start.color);
                    gion.color = ReturnAlphaColor(gion.color);
                    end.color = ReturnAlphaColor(end.color);


                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(SousaCoroutine());
                    }
                    break;

                case 2:
                    rect.localPosition = new Vector3(-360, -230, 0);

                    if (Time.timeScale == 0)
                    {
                        gion.color = GetAlphaColor(gion.color);
                    }
                    start.color = ReturnAlphaColor(start.color);
                    sousa.color = ReturnAlphaColor(sousa.color);
                    end.color = ReturnAlphaColor(end.color);


                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(GionCoroutine());
                    }
                    break;

                case 3:
                    rect.localPosition = new Vector3(100, -230, 0);

                    if (Time.timeScale == 0)
                    {
                        end.color = GetAlphaColor(end.color);
                    }
                    start.color = ReturnAlphaColor(start.color);
                    sousa.color = ReturnAlphaColor(sousa.color);
                    gion.color = ReturnAlphaColor(gion.color);


                    if (Input.GetButton("B"))
                    {
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
        if (Time.timeScale == 1)
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


    private IEnumerator StartCoroutine()    //StageNumberによってロードシーンを管理
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("ArakouStage");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator SousaCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("HelpAra");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator GionCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("GionAra");
        pushScene = false;
        Time.timeScale = 1;
    }
    private IEnumerator EndCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Application.Quit();
    }
}
