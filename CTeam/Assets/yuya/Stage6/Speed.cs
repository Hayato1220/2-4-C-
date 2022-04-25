using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public GameObject DestroyWall;  //破壊する壁を入れる変数   

    private Rigidbody rb;           // Rigidbody を受け取る変数 rb

    private static bool speedflag;                 //一定以上のスピードがでたら true にする

    public PhysicMaterial kabeslip;

    private BoxCollider myCollider;




    void Start()
    {
        speedflag = false;                          // speedflag を false で初期化

        rb = transform.GetComponent<Rigidbody>();   // rb に Rigidbody の transform を取得

        myCollider = GetComponent<BoxCollider>();

    }



    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);

        ////もしオブジェクトの移動速度が 3.0f 以上だったら
        //if (rb.velocity.magnitude >= 3.0f)
        //{
        //    speedflag = true;       // speedflag を true にする
        //}
        //else    //オブジェクトの移動速度が 3.0f 以下なら
        //{
        //    speedflag = false;      // speedflag を true にする
        //}
    }



    void OnCollisionEnter(Collision other)
    {
        //他のオブジェクトに当たった時に、タグが "Wall" だったら
        if (other.gameObject.tag == "ToumeiWall")
        {
            ////もし speedflag が true なら
            //if (speedflag == true)
            //{
            speedflag = true;

            Destroy(DestroyWall);       // DestroyWall に入れたオブジェクトを破壊する

            Destroy(this.gameObject);   //スクリプトがアタッチされているオブジェクトを破壊する

            //}
        }
    }


    public static bool GetSpeedFlag()
    {
        return speedflag;
    }
}
