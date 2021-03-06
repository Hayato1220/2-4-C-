using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gioncopy : MonoBehaviour
{

    private GameObject neba_P;

    private GameObject childObjneba;


    private bool getstage1flag;
    private bool getstage2flag;
    private bool getstage3flag;
    private bool getstage4flag;

    private bool subepush;              //すべすべを使ったかどうかの管理用フラグ

    private bool barapush;              //バラバラを使ったかどうかの管理用フラグ
    private GameObject baraObj;         //バラバラにしたオブジェクトを入れる変数


    public static bool byunpush;        //ビュンビュンを使ったかどうかの管理用フラグ
    private GameObject childObjbyun;    //触っているオブジェクトに入っている子オブジェクトを入れる変数


    /* 4つの色を持つオブジェクトをバラバラにした後に入れる変数 */
    private GameObject redCube;         //赤色のオブジェクトを入れる変数
    private GameObject greenCube;       //緑色のオブジェクトを入れる変数
    private GameObject blueCube;        //青色のオブジェクトを入れる変数
    private GameObject whiteCube;       //白色のオブジェクトを入れる変数


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

    /* エフェクト（パーティクル）用変数 */
    int ObjCount;


    void Start()
    {

        neba_P = Resources.Load("NebaEffect") as GameObject;
        

        subepush = false;
        barapush = false;   // barapush を false で初期化
        byunpush = false;   //　byunpush を false で初期化
        number = 0;         //リトライした時に number を初期化
    }



    void Update()
    {
        getstage1flag = Stage1.GetStage1Flag();
        getstage2flag = Stage2.GetStage2Flag();
        getstage3flag = Stage3.GetStage3Flag();
        getstage4flag = Stage4.GetStage4Flag();

        /*
         * Time.timeScale == 0 の時に擬音の切り替えができないように
         */
        if (Time.timeScale == 1)
        {
            GionChange();       //使える擬音をXボタンで切り替える

            GionChangeMove();   //使う擬音のフラグ管理

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

                /* ステージをクリアするごとに擬音を解放していく */
                //if (getstage1flag == true)
                //{
                //    number++;
                //    Debug.Log("ふわふわ解放");
                //    if (number > 1)
                //    {
                //        number = 0;
                //    }
                //}
                //else if (getstage1flag == false && getstage2flag == true)
                //{
                //    number++;
                //    Debug.Log("スケスケ解放");
                //    if (number > 2)
                //    {
                //        number = 0;
                //    }
                //} else if (getstage1flag == false && getstage2flag == false && getstage3flag == true)
                //{
                //    number++;
                //    Debug.Log("ビュンビュン解放");
                //    if (number > 3)
                //    {
                //        number = 0;
                //    }
                //}else if(getstage1flag == false && getstage2flag == false && getstage3flag == false && getstage4flag == true)
                //{
                //    number++;
                //    Debug.Log("バラバラとネバネバ解放");
                //    if(number > 5)
                //    {
                //        number = 0;
                //    }
                //}

                /* ここのコメントアウト直したら全部の擬音使えます */
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


        /* スケスケ */
        if (number == 2)                　 // number が2なら
        {
            sukeflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が2以外なら
        {
            sukeflag = false;
        }


        /* ビュンビュン */
        if (number == 3)                　 // number が3なら
        {
            byunflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が3以外なら
        {
            byunflag = false;
        }


        /* バラバラ */
        if (number == 4)                　 // number が4なら
        {
            baraflag = true;             // true の状態の時にしか処理が出来ないようにに管理しようとしてる
        }
        else                              // number が4以外なら
        {
            baraflag = false;
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
        if (other.gameObject.tag == "Object" || other.gameObject.tag == "Red" || other.gameObject.tag == "Green" || other.gameObject.tag == "Blue" || other.gameObject.tag == "White")
        {
            ObjCollider = other.gameObject.GetComponent<BoxCollider>();     // objCollider に触れているオブジェクトの BoxCollider を取得する

            ObjName = other.gameObject.name;                                // ObjName に触れているオブジェクトの名前を入れる

            Vector3 Objpos = other.gameObject.transform.position;           // Objpos に触れているオブジェクトの位置を入れる

            Vector3 ObjScale2 = other.gameObject.transform.localScale;      // ObjScale2 に、触れているオブジェクトの大きさを入れる


            mr = other.gameObject.GetComponent<MeshRenderer>();             //触れたオブジェクトの MeshRenderer を取得
            rb = other.gameObject.GetComponent<Rigidbody>();                //触れたオブジェクトの Rigidbody を取得


            ObjCount = other.gameObject.transform.childCount;

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
                            if (subepush == true)
                            {
                                subepush = false;

                                ObjCollider.material = slip;    // ObjCollider の PhysicMaterial を slip に入っているものを入れる

                                other.gameObject.AddComponent<SubeEffect>();

                                var s_metallic = other.gameObject.GetComponent<Renderer>();
                                s_metallic.material.SetFloat("_Metallic", 0.929f);
                                s_metallic.material.SetFloat("_Glossiness", 0.86f);
                            }
                        }
                        subepush = true;
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
                                    other.gameObject.AddComponent<HuwaEffect>();
                                    rb.velocity = transform.up * 2;     //オブジェクトを上に上げる
                                }
                            }
                            else // ObjName に入っている名前が"FloorMove"以外なら
                            {
                                other.gameObject.AddComponent<HuwaEffect>();
                                rb.velocity = transform.up * 2;         //オブジェクトを上に上げる
                            }
                        }
                    }
                    break;


                /* バラバラ */
                case 4:
                    //バラバラのフラグが　true なら
                    if (baraflag == true)
                    {
                        //もし Bボタンを押したら
                        if (Input.GetButton("B"))
                        {
                            //もし ObjName が"FourCube"なら
                            if (ObjName == "FourCube")
                            {
                                // barapush が true なら
                                if (barapush == true)
                                {
                                    barapush = false;   //ボタンを長押しが機能しないように false にする

                                    other.gameObject.AddComponent<BaraEffect>();

                                    // i が4以下の時繰り返す処理
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (i == 0)     // i が0の時
                                        {
                                            greenCube = other.gameObject.transform.GetChild(0).gameObject;      // greenCube に触れている親オブジェクトの子オブジェクト GreenCube を入れる

                                            greenCube.AddComponent<Rigidbody>();                    // greenCube に Rigidbody を追加
                                            greenCube.AddComponent<BoxCollider>();                  // greenCube に BoxCollider を追加


                                            var greenRb = greenCube.GetComponent<Rigidbody>();              // var で型にあった形に変えて、 greenCube の Rigidbody を取る

                                            greenRb.mass = 50;                                              //greenCube の mass(質量) を50にする
                                            greenRb.constraints = RigidbodyConstraints.FreezeRotation;      //greenCube の FreezeRotation すべてをオンにする


                                            Vector3 G_pos = greenCube.transform.localPosition;      // G_pos に greenCube の localPosition を入れる

                                            G_pos.x = G_pos.x - 1.5f;                               // G_pos.x に1.0f引いた値を代入
                                            G_pos.y = G_pos.y + 0.2f;                               // G_pos.y に1.0f足した値を代入

                                            greenCube.transform.localPosition = G_pos;              // greenCube の localPosition に G_pos のポジションを代入

                                            //Debug.Log(G_pos);
                                        }

                                        if (i == 1)     // i が1の時
                                        {
                                            whiteCube = other.gameObject.transform.GetChild(1).gameObject;      // whiteCube に触れている親オブジェクトの子オブジェクト WhiteCube を入れる

                                            whiteCube.AddComponent<Rigidbody>();                    // whiteCube に Rigidbody を追加
                                            whiteCube.AddComponent<BoxCollider>();                  // whiteCube に BoxCollider を追加


                                            var whiteRb = whiteCube.GetComponent<Rigidbody>();               // var で型にあった形に変えて、 whiteCube の Rigidbody を取る

                                            whiteRb.mass = 50;                                              //whiteCube の mass(質量) を50にする
                                            whiteRb.constraints = RigidbodyConstraints.FreezeRotation;      //whiteCube の FreezeRotation すべてをオンにする


                                            Vector3 W_pos = whiteCube.transform.localPosition;      // W_pos に whiteCube の localPosition を入れる

                                            W_pos.x = W_pos.x + 1.5f;                               // W_pos.x に1.0f足した値を代入
                                            W_pos.y = W_pos.y + 0.2f;                               // W_pos.y に1.0f足した値を代入

                                            whiteCube.transform.localPosition = W_pos;              // whiteCube の localPosition に W_pos のポジションを代入
                                        }

                                        if (i == 2)     // i が2の時
                                        {
                                            redCube = other.gameObject.transform.GetChild(2).gameObject;        // redCube に触れている親オブジェクトの子オブジェクト　RedCube を入れる

                                            redCube.AddComponent<Rigidbody>();                      // redCube に Rigidbody を追加
                                            redCube.AddComponent<BoxCollider>();                    // redCube に BoxCollider を追加


                                            var redRb = redCube.GetComponent<Rigidbody>();                  // var で型にあった形に変えて、 redCube の Rigidbody を取る

                                            redRb.mass = 50;                                                //redCube の mass(質量) を50にする
                                            redRb.constraints = RigidbodyConstraints.FreezeRotation;        //redCube の FreezeRotation すべてをオンにする


                                            Vector3 R_pos = redCube.transform.localPosition;        // R_pos に redCube の localPosition を入れる

                                            R_pos.x = R_pos.x - 0.1f;                               // R_pos.x に1.0f引いた値を代入
                                            R_pos.y = R_pos.y + 1.0f;

                                            redCube.transform.localPosition = R_pos;                // redCube の localPosition に R_pos のポジションを代入
                                        }

                                        if (i == 3)     // i が3の時
                                        {
                                            blueCube = other.gameObject.transform.GetChild(3).gameObject;       // blueCube に触れている親オブジェクトの子オブジェクト BlueCube を入れる

                                            blueCube.AddComponent<Rigidbody>();                     // blueCube に Rigidbody を追加
                                            blueCube.AddComponent<BoxCollider>();                   // blueCube に BoxCollider を追加


                                            var blueRb = blueCube.GetComponent<Rigidbody>();                // var で型にあった形に変えて、 blueCube の Rigidbody を取る

                                            blueRb.mass = 50;                                               //blueCube の mass(質量) を50にする
                                            blueRb.constraints = RigidbodyConstraints.FreezeRotation;       //blueCube の FreezeRotation すべてをオンにする


                                            Vector3 B_pos = blueCube.transform.localPosition;       // B_pos に blueCube の localPosition を入れる

                                            B_pos.x = B_pos.x + 0.1f;                               // B_pos.x に1.0f引いた値を代入
                                            B_pos.y = B_pos.y + 1.0f;

                                            blueCube.transform.localPosition = B_pos;               // blueCube の localPosition に B_pos のポジションを代入
                                        }

                                        Destroy(other.gameObject.GetComponent<BoxCollider>());      //触れている親オブジェクトの BoxCollider を削除
                                    }
                                }
                            }
                            else    // ObjName == "FourCube" 以外なら
                            {
                                //もし触れているオブジェクトの X(横幅)の大きさが0.125(四等分)を超えていなかったら
                                if (ObjScale2.x > 0.125)
                                {
                                    //もし barapush が true なら
                                    if (barapush == true)
                                    {
                                        barapush = false;   //ボタンを長押しが機能しないように false にする

                                        other.gameObject.AddComponent<BaraEffect>();

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
                case 3:
                    //ビュンビュンのフラグが true なら
                    if (byunflag == true)
                    {
                        //もしBボタンを押したら
                        if (Input.GetButton("B"))
                        {
                            // byunpush が true なら
                            if (byunpush == true)
                            {
                                byunpush = false;       //長押しできないように byunpush を false にする

                                rb.AddForce((transform.forward * 10.0f) + (transform.up * 7.0f), ForceMode.VelocityChange);     //触れているオブジェクトを質量に関係なく飛ばす

                                other.gameObject.AddComponent<ByunEffect>();

                                //if (ObjCount == 0)
                                //{
                                //    childObjbyun = (GameObject)Instantiate(byun_P, other.transform.position, Quaternion.identity);
                                //    childObjbyun.transform.parent = other.gameObject.transform;
                                //}
                                //else
                                //{
                                //    Destroy(other.transform.GetChild(0).gameObject);

                                //    childObjbyun = (GameObject)Instantiate(byun_P, other.transform.position, Quaternion.identity);
                                //    childObjbyun.transform.parent = other.gameObject.transform;
                                //}

                                /*
                                 * 飛んで行ったオブジェクトに入っている
                                 * 子オブジェクトを地面に着いたら破壊したい
                                 */
                                //Destroy(other.gameObject.transform.GetChild(0).gameObject);
                            }

                        }
                        else    //Bボタンが押されていない間は
                        {
                            byunpush = true;            // byunpush を true にする
                        }
                    }
                    break;

                /* ネバネバ */
                case 5:
                    //ネバネバのフラグが true なら
                    if (nebaflag == true)
                    {
                        //もしBボタンを押したら
                        if (Input.GetButton("B"))
                        {
                            //other.gameObject.AddComponent<neba>();
                            childObjneba = (GameObject)Instantiate(neba_P, other.transform.position, Quaternion.identity);
                            childObjneba.transform.parent = other.gameObject.transform;
                            ObjCollider.material = nebaneba;    //触れているオブジェクトの material に nebaneba を入れる
                        }
                    }
                    break;
            }
        }
    }


    /*
     * 他のオブジェクトに触れている間の処理
     * 切り替えた擬音に対応する動作
     */
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Object")
        {
            // number 2(スケスケ)
            switch (number)
            {

                /* スケスケ */
                case 2:
                    //スケスケのフラグが true なら
                    if (sukeflag == true)
                    {
                        //もしBボタンを押したら
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
            }
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
