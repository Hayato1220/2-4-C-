using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nbnb : MonoBehaviour
{

    //変数を作る
    Rigidbody rb;

    //ゲーム起動時に呼び出される
    void Start()
    {
        //Rigidbodyを取得
        rb = GetComponent<Rigidbody>();

        //動かす
        //rb.AddForce(10, 0, 0);

    }

    //毎フレーム(いっぱい！)ごと呼ばれる
    void Update()
    {
        //もしスペースキーが押されたら
        if (Input.GetKey(KeyCode.Space))
        {
            //Rigidbodyを停止
            rb.velocity = Vector3.zero;
        }
    }
}