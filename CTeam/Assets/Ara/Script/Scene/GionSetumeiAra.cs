using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GionSetumeiAra : MonoBehaviour
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

    public Text sube;
    public Text fuwa;
    public Text suke;
    public Text byun;
    public Text bara;
    public Text neba;

    bool getpauseflag;

    void Start()
    {
        rect = GetComponent<RectTransform>();   //オブジェクトの位置を取得

        sube = sube.GetComponent<Text>();
        fuwa = fuwa.GetComponent<Text>();
        suke = suke.GetComponent<Text>();
        byun = byun.GetComponent<Text>();
        bara = bara.GetComponent<Text>();
        neba = neba.GetComponent<Text>();

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
                    if (++MenuNumber > 5)    // MenuNumber　を先に1プラスした時に、 ３以上なら
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
                        MenuNumber = 5;
                    }

                }
            }
            else if(!Input.GetButton("B") && Input.GetAxis("L_Stick_H") == 1 || (!Input.GetButton("B") && Input.GetAxis("PadKey_H") == 1))
            {
                if (pushflag == false)      // pushflag が false の時
                {
                    pushflag = true;
                    CursorMove.Play();
                    if (MenuNumber == 0)    
                    {
                        MenuNumber = 3;    
                    }
                    else if (MenuNumber == 1)
                    {
                        MenuNumber = 4;
                    }
                    else if (MenuNumber == 2)
                    {
                        MenuNumber = 5;
                    }
                    else if (MenuNumber == 3)
                    {
                        MenuNumber = 0;
                    }
                    else if (MenuNumber == 4)
                    {
                        MenuNumber = 1;
                    }
                    else if (MenuNumber == 5)
                    {
                        MenuNumber = 2;
                    }
                }
            }
            else if (!Input.GetButton("B") && Input.GetAxis("L_Stick_H") == -1 || (!Input.GetButton("B") && Input.GetAxis("PadKey_H") == -1))
            {
                if (pushflag == false)      // pushflag が false の時
                {
                    pushflag = true;
                    CursorMove.Play();
                    if (MenuNumber == 3)
                    {
                        MenuNumber = 0;
                    }
                    else if (MenuNumber == 4)
                    {
                        MenuNumber = 1;
                    }
                    else if (MenuNumber == 5)
                    {
                        MenuNumber = 2;
                    }
                    else if (MenuNumber == 2)
                    {
                        MenuNumber = 5;
                    }
                    else if (MenuNumber == 1)
                    {
                        MenuNumber = 4;
                    }
                    else if (MenuNumber == 0)
                    {
                        MenuNumber = 3;
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
                    rect.localPosition = new Vector3(-380, 100, 0);

                    if (Time.timeScale == 0)
                    {
                        sube.color = GetAlphaColor(sube.color);
                    }
                    fuwa.color = ReturnAlphaColor(fuwa.color);
                    suke.color = ReturnAlphaColor(suke.color);
                    byun.color = ReturnAlphaColor(byun.color);
                    bara.color = ReturnAlphaColor(bara.color);
                    neba.color = ReturnAlphaColor(neba.color);

                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(SubeCoroutine());
                    }
                    break;

                case 1:
                    rect.localPosition = new Vector3(-380, -50, 0);

                    if (Time.timeScale == 0)
                    {
                        fuwa.color = GetAlphaColor(fuwa.color);
                    }
                    sube.color = ReturnAlphaColor(sube.color);
                    suke.color = ReturnAlphaColor(suke.color);
                    byun.color = ReturnAlphaColor(byun.color);
                    bara.color = ReturnAlphaColor(bara.color);
                    neba.color = ReturnAlphaColor(neba.color);

                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(FuwaCoroutine());
                    }
                    break;

                case 2:
                    rect.localPosition = new Vector3(-380, -200, 0);

                    if (Time.timeScale == 0)
                    {
                        suke.color = GetAlphaColor(suke.color);
                    }
                    sube.color = ReturnAlphaColor(sube.color);
                    fuwa.color = ReturnAlphaColor(fuwa.color);
                    byun.color = ReturnAlphaColor(byun.color);
                    bara.color = ReturnAlphaColor(bara.color);
                    neba.color = ReturnAlphaColor(neba.color);

                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(SukeCoroutine());
                    }
                    break;

                case 3:
                    rect.localPosition = new Vector3(120, 100, 0);

                    if (Time.timeScale == 0)
                    {
                        byun.color = GetAlphaColor(byun.color);
                    }
                    sube.color = ReturnAlphaColor(sube.color);
                    fuwa.color = ReturnAlphaColor(fuwa.color);
                    suke.color = ReturnAlphaColor(suke.color);
                    bara.color = ReturnAlphaColor(bara.color);
                    neba.color = ReturnAlphaColor(neba.color);

                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(ByunCoroutine());
                    }
                    break;

                case 4:
                    rect.localPosition = new Vector3(120, -50, 0);

                    if (Time.timeScale == 0)
                    {
                        bara.color = GetAlphaColor(bara.color);
                    }
                    sube.color = ReturnAlphaColor(sube.color);
                    fuwa.color = ReturnAlphaColor(fuwa.color);
                    suke.color = ReturnAlphaColor(suke.color);
                    byun.color = ReturnAlphaColor(byun.color);
                    neba.color = ReturnAlphaColor(neba.color);

                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(BaraCoroutine());
                    }
                    break;

                case 5:
                    rect.localPosition = new Vector3(120, -200, 0);

                    if (Time.timeScale == 0)
                    {
                        neba.color = GetAlphaColor(neba.color);
                    }
                    sube.color = ReturnAlphaColor(sube.color);
                    fuwa.color = ReturnAlphaColor(fuwa.color);
                    suke.color = ReturnAlphaColor(suke.color);
                    byun.color = ReturnAlphaColor(byun.color);
                    bara.color = ReturnAlphaColor(bara.color);

                    if (Input.GetButton("B"))
                    {
                        CursorCheck.Play();     //音を鳴らす
                        pushScene = true;
                        StartCoroutine(NebaCoroutine());
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


    private IEnumerator SubeCoroutine()    //StageNumberによってロードシーンを管理
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("subeAra");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator FuwaCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("fuwaAra");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator SukeCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("sukeAra");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator ByunCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("byunAra");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator BaraCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("baraAra");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator NebaCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        SceneManager.LoadScene("nebaAra");
        pushScene = false;
        Time.timeScale = 1;
    }

    private IEnumerator EndCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Application.Quit();
    }
}
