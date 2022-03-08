using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gion : MonoBehaviour
{
    private GameObject obj;             //このスクリプトがアタッチされているオブジェクトを参照する

    private BoxCollider ObjCollider;    //このスクリプトがアタッチされているオブジェクトの BoxCollider を参照する

    public PhysicMaterial slip;         //他の PhysicMaterial を　slip に入れる

    private int number = 0;             //擬音の動作を切り替える時に使う変数

    private bool subeflag = false;      //すべすべを管理する bool 型変数
    private bool huwaflag = false;      //ふわふわを管理する bool 型変数
    private bool baraflag = false;      //バラバラを管理する bool 型変数
    private bool byunflag = false;      //ビューンを管理する bool 型変数
    private bool sukeflag = false;      //スケスケを管理する bool 型変数

    bool pushflag = false;              //切り替えるボタンが押されたかどうか管理する bool 型変数



    void Start()
    {
        
    }


    /* 
     * ここから 
     */

    void Update()
    {

        GionChange();   //使える擬音をXボタンで切り替える

        GionAttach();   //切り替えた擬音の処理動作

        //Debug.Log(pushflag);

        if (number == 0)
        {
            subeflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else
        {
            subeflag = false;
        }

        if (Input.GetButton("A"))
        {
            Debug.Log(number);
        }
    }



    //擬音をXボタンで切り替える処理
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



    //切り替えた擬音に対応する処理
    void GionAttach()
    {
        // number でどの擬音の動作をするかを管理
        switch (number)
        {
            //すべすべ
            case 0:
                if (pushflag == true)   // pushflag が true なら（このif文処理いらないかも）
                {
                    Subesube();     //すべすべの動作
                }
                break;

            //ふわふわ
            case 1:
                if (pushflag == true)   // pushflag が true なら（このif文処理いらないかも）
                {
                    Huwahuwa();     //ふわふわの動作
                }
                break;

            //バラバラ
            case 2:
                if (pushflag == true)   // pushflag が true なら（このif文処理いらないかも）
                {
                    Barabara();     //バラバラの動作
                }
                break;

            //スケスケ
            case 3:
                if (pushflag == true)   // pushflag が true なら（このif文処理いらないかも）
                {
                    Sukesuke();     //スケスケの動作
                }
                break;

            //ビュンビュン
            case 4:
                if (pushflag == true)   // pushflag が true なら（このif文処理いらないかも）
                {
                    Byunbyun();     //ビュンビュンの動作
                }
                break;
        }
    }



    //プレイヤーが当たっている他のオブジェクトについての処理
    void OnCollisionStay(Collision other)
    {
        //もし当たったオブジェクトのタグが"Object"なら
        if (other.gameObject.tag == "Object")
        {
            ObjCollider = other.gameObject.GetComponent<BoxCollider>();     // objCollider に触れている他のオブジェクトの BoxCollider を取得する
            //Debug.Log(ObjCollider);

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
        }

    }



    //すべすべの処理
    private void Subesube()
    {


        //もしBボタンを押したら
        if (Input.GetButton("B"))
        {
            Debug.Log("すべすべ");
        }
    }


    //ふわふわの処理
    private void Huwahuwa()
    {
        huwaflag = true;            // true の状態の時にしか処理が出来ないようにに管理しようとしてる

        //もしBボタンを押したら
        if (Input.GetButton("B")){
            Debug.Log("ふわふわ");
        }
    }


    //バラバラの処理
    private void Barabara()
    {
        baraflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる

        //もしBボタンを押したら
        if (Input.GetButton("B"))
        {
            Debug.Log("バラバラ");
        }
    }


    //スケスケの処理
    private void Sukesuke()
    {
        sukeflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる

        //もしBボタンを押したら
        if (Input.GetButton("B"))
        {
            Debug.Log("スケスケ");
        }
    }


    //ビュンビュンの処理
    private void Byunbyun()
    {
        byunflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる

        //もしBボタンを押したら
        if (Input.GetButton("B"))
        {
            Debug.Log("ビュンビュン");
        }
    }
}
