using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gion : MonoBehaviour
{
    bool barapush;                      //バラバラを使ったかどうかのフラグ管理
    private GameObject baraObj;         //バラバラにしたオブジェクトを入れる変数

    /* 4つの色を持つオブジェクトをバラバラにした後に入れる変数 */
    private GameObject redCube;
    private GameObject greenCube;
    private GameObject blueCube;
    private GameObject whiteCube;

    private MeshRenderer green;

    private GameObject obj;             //このスクリプトがアタッチされているオブジェクトを参照する
    private BoxCollider ObjCollider;    //衝突したオブジェクトの BoxCollider を参照する
    public PhysicMaterial slip;         //他の PhysicMaterial を　slip に入れる

    private static int number;          //擬音の動作を切り替える時に使う変数
    bool pushflag = false;              //切り替えるボタンが押されたかどうか管理する bool 型変数

    private bool subeflag = false;      //すべすべを管理する bool 型変数
    private bool huwaflag = false;      //ふわふわを管理する bool 型変数
    private bool baraflag = false;      //バラバラを管理する bool 型変数
    private bool byunflag = false;      //ビューンを管理する bool 型変数
    private bool sukeflag = false;      //スケスケを管理する bool 型変数
    private bool nebaflag = false;      //ネバネバを管理する bool 型変数



    private MeshRenderer mr;

    private Rigidbody rb;

    public PhysicMaterial nebaneba;


    string ObjName;                     //触れたオブジェクトの名前を受け取る変数

    private float impulseMagnitude;
    private bool byunpush;


    void Start()
    {
        barapush = false;   // barapush を false で初期化
        byunpush = false;
        number = 0;         //リトライした時に number を初期化

        impulseMagnitude = 50.0f;
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

                //もし number が5以下なら
                if (number < 5)
                {

                    number++;         // number を1ずつ増やす

                }
                //もし number が5以下以外なら
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
        /* すべすべ */
        if (number == 0)                　 // number が0なら
        {
            subeflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が0以外なら
        {
            subeflag = false;
        }


        /* ふわふわ */
        if (number == 1)                　 // number が1なら
        {
            huwaflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が1以外なら
        {
            huwaflag = false;
        }


        /* バラバラ */
        if (number == 2)                　 // number が2なら
        {
            baraflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が2以外なら
        {
            baraflag = false;
        }


        /* スケスケ */
        if (number == 3)                　 // number が3なら
        {
            sukeflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が3以外なら
        {
            sukeflag = false;
        }


        /* ビュンビュン */
        if (number == 4)                　 // number が4なら
        {
            byunflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が4以外なら
        {
            byunflag = false;
        }

        /* ネバネバ */
        if (number == 5)                　 // number が5なら
        {
            nebaflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が5以外なら
        {
            nebaflag = false;
        }
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
            ObjCollider = other.gameObject.GetComponent<BoxCollider>();     // objCollider に触れているオブジェクトの BoxCollider を取得する

            ObjName = other.gameObject.name;                                // ObjName に触れているオブジェクトの名前を入れる

            Vector3 Objpos = other.gameObject.transform.position;           // Objpos に触れているオブジェクトの位置を入れる

            Vector3 ObjScale2 = other.gameObject.transform.localScale;      // ObjScale2 に、触れているオブジェクトの大きさを入れる

            //Debug.Log(ObjCollider);

            mr = other.gameObject.GetComponent<MeshRenderer>();
            rb = other.gameObject.GetComponent<Rigidbody>();

            /* * * * * * * * * *
             * 0:すべすべ      *
             * 1:ふわふわ      *
             * 2:バラバラ      *
             * 3:スケスケ      *
             * 4:ビュンビュン  *
             * 5:ネバネバ      *
             * * * * * * * * * */
            switch (number)
            {
                /* すべすべ */
                case 0:
                    //すべすべのフラグが true なら
                    if (subeflag == true)
                    {
                        //もし他のオブジェクトに当たっている状態でBボタンを押すと
                        if (Input.GetButton("B"))
                        {
                            ObjCollider.material = slip;    // ObjCollider の PhysicMaterial を slip に入っているものを入れる
                        }
                    }
                    break;


                /* ふわふわ */
                case 1:
                    //ふわふわのフラグが true なら
                    if (huwaflag == true)
                    {
                        //もし他のオブジェクトに当たっている状態でBボタンを押すと
                        if (Input.GetButton("B"))
                        {
                            Debug.Log(ObjName);
                            // ObjName に入っている名前が"FloorMove"なら
                            if (ObjName == "FloorMove")
                            {
                                // もし触れているオブジェクトの高さが8以下なら
                                if (Objpos.y < 8)
                                {
                                    rb.velocity = transform.up * 2;     //オブジェクトを上に上げる
                                }
                            }
                            else // ObjName に入っている名前が"FloorMove"以外なら
                            {
                                rb.velocity = transform.up * 2;         //オブジェクトを上に上げる
                            }
                        }
                    }
                    break;


                /* バラバラ */
                case 2:
                    //バラバラのフラグが　true なら
                    if (baraflag == true)
                    {
                        //もし Bボタンを押したら
                        if (Input.GetButton("B"))
                        {
                            if(ObjName == "FourCube")
                            {
                                if (barapush == true)
                                {
                                    barapush = false;   //ボタンを長押しが機能しないように false にする

                                    for (int i = 0; i < 4; i++)
                                    {
                                        if(i == 0)
                                        {
                                            greenCube = transform.GetChild(0).gameObject;

                                            Vector3 G_pos = greenCube.transform.localPosition;
                                            G_pos.x = G_pos.x - 10.0f;
                                            G_pos.y = G_pos.y + 20.0f;

                                            greenCube.transform.localPosition = G_pos;

                                            Debug.Log(G_pos);

                                            //redCube = Instantiate(other.gameObject, Objpos + (transform.up * 1.5f) + (transform.right * -2.0f), Quaternion.identity);   // Instantiate(クローンのもとになるオブジェクト, 位置, 回転)してオブジェクトを生成

                                            //redCube.AddComponent<Renderer>();
                                            //redCube.gameObject.name = "RedCube";

                                            //redCube.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 0);

                                            //Vector3 ObjScale = other.gameObject.transform.localScale;   // ObjScale に、触れているオブジェクトの大きさを入れる

                                            //ObjScale.x = ObjScale.x / 2.0f;                             // ObjScale の X(横幅)の大きさを半分にする
                                            //ObjScale.y = ObjScale.y / 2.0f;

                                            //redCube.transform.localScale = ObjScale;                    //生成するオブジェクトに ObjScale の値を入れる
                                        }

                                        if(i == 1)
                                        {
                                            whiteCube = transform.GetChild(1).gameObject;

                                            Vector3 W_pos = whiteCube.transform.localPosition;
                                            W_pos.x = W_pos.x + 10.0f;
                                            W_pos.y = W_pos.y + 20.0f;

                                            whiteCube.transform.localPosition = W_pos;
                                        }

                                    }

                                    //Destroy(other.gameObject);
                                }
                            }
                            else
                            {
                                //もし触れているオブジェクトの X(横幅)の大きさが0.125(四等分)を超えていなかったら
                                if (ObjScale2.x > 0.125)
                                {
                                    //もし barapush が true なら
                                    if (barapush == true)
                                    {
                                        barapush = false;   //ボタンを長押しが機能しないように false にする

                                        //触れているオブジェクトを半分にする
                                        for (int i = 0; i < 2; i++)
                                        {

                                            baraObj = Instantiate(other.gameObject, Objpos + (transform.up * 1.5f), Quaternion.identity);   // Instantiate(クローンのもとになるオブジェクト, 位置, 回転)してオブジェクトを生成

                                            Vector3 ObjScale = other.gameObject.transform.localScale;   // ObjScale に、触れているオブジェクトの大きさを入れる

                                            ObjScale.x = ObjScale.x / 2.0f;                             // ObjScale の X(横幅)の大きさを半分にする
                                            ObjScale.y = ObjScale.y / 2.0f;
                                            ObjScale.z = ObjScale.z / 2.0f;

                                            baraObj.transform.localScale = ObjScale;                    //生成するオブジェクトに ObjScale の値を入れる

                                            //// Instantiate(クローンのもとになるオブジェクト, 位置, 回転)
                                            //baraObj2 = Instantiate(other.gameObject, Objpos + (transform.up * 1.5f), Quaternion.identity);

                                            //ObjScale2.x = ObjScale2.x / 2.0f;
                                            //baraObj2.transform.localScale = ObjScale2;
                                        }
                                        //hanbun = hanbun * 2;
                                        Destroy(other.gameObject);  //触れていたオブジェクトを消す
                                    }
                                }
                            }
                        }
                        else    // Bボタンを押していない間は
                        {
                            barapush = true;        // barapush を true にする
                        }
                    }
                    break;

                /* ビュンビュン */
                case 4:
                    if (byunflag == true)
                    {
                        if (Input.GetButton("B"))
                        {
                            if(byunpush == true)
                            {
                                byunpush = false;

                                rb.AddForce((transform.forward * 10.0f) + (transform.up * 7.0f), ForceMode.VelocityChange);
                            }
                        }
                        else
                        {
                            byunpush = true;
                        }
                    }
                    break;

            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        switch (number)
        {

            /* スケスケ */
            case 3:
                if (sukeflag == true)
                {
                    if (Input.GetButton("B"))
                    {
                        mr.material.color = mr.material.color - new Color32(0, 0, 0, 5);
                    }

                    if (mr.material.color.a <= 0)
                    {
                        Destroy(other.gameObject);
                    }
                }

                break;
            /* ネバネバ */
            case 5:
                if (nebaflag == true)
                {
                    if (Input.GetButton("B"))
                    {
                        ObjCollider.material = nebaneba;
                    }
                }
                break;
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
