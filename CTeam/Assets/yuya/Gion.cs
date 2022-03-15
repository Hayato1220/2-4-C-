using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gion : MonoBehaviour
{
    //バラバラに使う変数たち
    bool barapush;

    int baracount;

    private GameObject baraObj;




    private GameObject obj;             //このスクリプトがアタッチされているオブジェクトを参照する

    private BoxCollider ObjCollider;    //衝突したオブジェクトの BoxCollider を参照する

    public PhysicMaterial slip;         //他の PhysicMaterial を　slip に入れる

    private static int number;             //擬音の動作を切り替える時に使う変数

    private bool subeflag = false;      //すべすべを管理する bool 型変数
    private bool huwaflag = false;      //ふわふわを管理する bool 型変数
    private bool baraflag = false;      //バラバラを管理する bool 型変数
    private bool byunflag = false;      //ビューンを管理する bool 型変数
    private bool sukeflag = false;      //スケスケを管理する bool 型変数

    bool pushflag = false;              //切り替えるボタンが押されたかどうか管理する bool 型変数



    void Start()
    {
        barapush = false;
        baracount = 0;

        number = 0;     //リトライした時に number を初期化
    }



    /*
     * Time.timeScale = 0 の時に止まれるように FixedUpdate で管理
     */
    void FixedUpdate()
    {

        GionChange();       //使える擬音をXボタンで切り替える

        GionChangeMove();   //使う擬音のフラグ管理

    }



    /*
     * プレイヤーが当たっている他のオブジェクトについての処理
     * 切り替えた擬音に対応する動作
     */
    void OnCollisionStay(Collision other)
    {
        //もし当たったオブジェクトのタグが"Object"なら
        if (other.gameObject.tag == "Object")
        {
            ObjCollider = other.gameObject.GetComponent<BoxCollider>();     // objCollider に触れている他のオブジェクトの BoxCollider を取得する

            Vector3 Objpos = other.gameObject.transform.position;

            Debug.Log(ObjCollider);


            //すべすべのフラグが true なら
            if (subeflag == true)
            {
                //他のオブジェクトに当たっている状態でBボタンを押すと
                if (Input.GetButton("B"))
                {
                    //すべすべにする
                    ObjCollider.material = slip;    // ObjCollider の PhysicMaterial を slip に入っているものを入れる
                }
            }


            //バラバラのフラグが　true なら
            if(baraflag == true)
            {

                if (Input.GetButton("B"))
                {
                    if (barapush == true)
                    {
                        barapush = false;

                        if(baracount == 0)
                        {
                            for(int i = 0; i < 2; i++)
                            {
                                // Instantiate(クローンのもとになるオブジェクト, 位置, 回転)
                                baraObj = Instantiate(other.gameObject, Objpos + (transform.forward * 1.5f), Quaternion.identity);
                                Vector3 ObjScale = gameObject.transform.localScale;

                                ObjScale.x = ObjScale.x / 2.0f;

                                baraObj.transform.localScale = ObjScale;

                            }
                        }

                    }
                }
                else
                {
                    barapush = true;
                }
            }
        }
    }



    /*
     * 擬音をXボタンで切り替える処理
     */
    void GionChange()
    {
        //もしXボタンを押したら
        if (Input.GetButton("X"))
        {
            // pushflag が true なら
            if (pushflag == true)
            {
                pushflag = false;      //何回も処理しないように pushflag を false にする

                //もし number が4以下なら
                if (number < 4)
                {

                    number++;         // number を1ずつ増やす

                }
                //もし number が4以下以外なら
                else
                {

                    number = 0;      // number を0にして最初に戻す

                }
            }
        }
        //Xボタンを押していない間は
        else
        {

            pushflag = true;         // pushflag を true にする

        }
    }


    /*
     * 切り替えた時に他の擬音の処理をしないように管理
     */
    void GionChangeMove()
    {
        if (number == 0)                　 // number が0なら
        {
            subeflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が0以外なら
        {
            subeflag = false;
        }

        if (number == 1)                　 // number が1なら
        {
            huwaflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が1以外なら
        {
            huwaflag = false;
        }

        if (number == 2)                　 // number が2なら
        {
            baraflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が2以外なら
        {
            baraflag = false;
        }

        if (number == 3)                　 // number が3なら
        {
            sukeflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が3以外なら
        {
            sukeflag = false;
        }

        if (number == 4)                　 // number が4なら
        {
            byunflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が4以外なら
        {
            byunflag = false;
        }
    }


    /*
     * GionChangeText スクリプトで使うように値を返す
     */
    public static int ChangeNumber()
    {
        return number;
    }
}
