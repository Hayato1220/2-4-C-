using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gion : MonoBehaviour
{
    private GameObject obj;

    private BoxCollider ObjCollider;

    public PhysicMaterial slip;

    private int number = 0;

    private bool subeflag = false;  //すべすべ
    private bool huwaflag = false;  //ふわふわ
    private bool baraflag = false;  //バラバラ
    private bool byunflag = false;  //ビューン
    private bool sukeflag = false;  //スケスケ

    bool buttonflag = false;
    bool flag = false;

    void Start()
    {

    }

    void Update()
    {
        if (buttonflag == false)
        {
            if (Input.GetButton("X"))
            {
                buttonflag = true;
            }
        }

        if (buttonflag == true)
        {
            if (subeflag == true)
            {
                number = 1;
                buttonflag = false;
            }
            else if (huwaflag == true)
            {
                number = 2;
                buttonflag = false;
            }
            else if (baraflag == true)
            {
                number = 3;
                buttonflag = false;
            }
            else if (sukeflag == true)
            {
                number = 4;
                buttonflag = false;
            }
            else if (byunflag == true)
            {

                number = 0;
                buttonflag = false;
            }
        }

        //buttonflag = true;
        //if (buttonflag == true)
        //{
        //    number++;
        //    buttonflag = false;
        //}

        if (buttonflag == true)
        {
            if (subeflag == false && huwaflag == false && baraflag == false && sukeflag == false && byunflag == false)
            {
                subeflag = true;  //すべすべ
                huwaflag = false;  //ふわふわ
                baraflag = false;  //バラバラ
                byunflag = false;  //ビューン
                sukeflag = false;  //スケスケ

                buttonflag = false;
            }

            if (subeflag == true && huwaflag == false && baraflag == false && sukeflag == false && byunflag == false)
            {

                subeflag = false;  //すべすべ
                huwaflag = true;  //ふわふわ
                baraflag = false;  //バラバラ
                byunflag = false;  //ビューン
                sukeflag = false;  //スケスケ

                buttonflag = false;
            }

            if (subeflag == false && huwaflag == true && baraflag == false && sukeflag == false && byunflag == false)
            {
                subeflag = false;  //すべすべ
                huwaflag = false;  //ふわふわ
                baraflag = true;  //バラバラ
                byunflag = false;  //ビューン
                sukeflag = false;  //スケスケ

                buttonflag = false;
            }

            if(subeflag == false && huwaflag == false && baraflag == true && sukeflag == false && byunflag == false)
            {
                subeflag = false;  //すべすべ
                huwaflag = false;  //ふわふわ
                baraflag = false;  //バラバラ
                sukeflag = true;  //スケスケ
                byunflag = false;  //ビューン

                buttonflag = false;
            }

            if (subeflag == false && huwaflag == false && baraflag == true && sukeflag == true && byunflag == false)
            {
                subeflag = false;  //すべすべ
                huwaflag = false;  //ふわふわ
                baraflag = false;  //バラバラ
                sukeflag = false;  //スケスケ
                byunflag = true;  //ビューン

                buttonflag = false;
            }
        }

        GionChange();

        Debug.Log(buttonflag);

        if (Input.GetButton("A"))
        {
            Debug.Log(number);
        }
    }



    void GionChange()
    {
        if (subeflag == true)
        {
            if (Input.GetButton("B"))
            {
                SubeSube();
            }
        }
        else if (huwaflag == true)
        {
            Huwahuwa();
            Debug.Log("ふわふわ");
        }
        else if (baraflag == true)
        {
            Barabara();
            Debug.Log("バラバラ");
        }
        else if (sukeflag == true)
        {
            Sukesuke();
            Debug.Log("スケスケ");
        }
        else if (byunflag == true)
        {
            Byunbyun();
            Debug.Log("ビュンビュン");
        }

        //switch (number)
        //{
        //    case 0: //すべすべ
        //        if (subeflag == true)
        //        {
        //            Debug.Log("すべすべ");
        //            if (Input.GetButton("B"))
        //            {
        //                SubeSube();
        //            }
        //        }
        //        huwaflag = true;
        //        break;

        //    case 1: //ふわふわ
        //        subeflag = false;
        //        if (huwaflag == true)
        //        {
        //            Huwahuwa();
        //            Debug.Log("ふわふわ");
        //        }
        //        baraflag = true;
        //        break;

        //    case 2: //バラバラ
        //        huwaflag = false;
        //        if (baraflag == true)
        //        {
        //            Barabara();
        //            Debug.Log("バラバラ");
        //        }
        //        sukeflag = true;
        //        break;

        //    case 3: //スケスケ
        //        baraflag = false;
        //        if (sukeflag == true)
        //        {
        //            Sukesuke();
        //            Debug.Log("スケスケ");
        //        }
        //        byunflag = false;
        //        break;

        //    case 4: //ビュンビュン
        //        sukeflag = false;
        //        if (byunflag == true)
        //        {
        //            Byunbyun();
        //            Debug.Log("ビュンビュン");
        //        }
        //        subeflag = true;
        //        break;
        //}
    }


    void OnCollisionStay(Collision other)
    {


        if (other.gameObject.tag == "Object")
        {
            ObjCollider = other.gameObject.GetComponent<BoxCollider>();

            //Debug.Log(ObjCollider);

            //すべすべにする
            //if (Input.GetButton("B"))
            //{
            //    ObjCollider.material = slip;
            //}

        }
    }


    //すべすべの処理
    void SubeSube()
    {
        //すべすべにする
        ObjCollider.material = slip;
    }

    //バラバラの処理
    void Barabara()
    {

    }

    //スケスケの処理
    void Sukesuke()
    {

    }

    //すべすべの処理
    void Byunbyun()
    {

    }

    //ふわふわの処理
    void Huwahuwa()
    {

    }
}
