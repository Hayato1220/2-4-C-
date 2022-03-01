using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    //1フレーム前の位置
    private Vector3 _prevPosition;

    private static float speed;


    private void Start()
    {
        //初期位置を保持
        _prevPosition = transform.position;

    }

    private void Update()
    {
        //deltaTimeが0の場合は何もしない
        if (Mathf.Approximately(Time.deltaTime, 0))
        {
            return;
        }

        //現在位置取得
        var position = transform.position;

        //現在速度計算
        var speed = (position - _prevPosition) / Time.deltaTime;


        //現在速度をログ出力
        print($"velocity = {speed}");

        Debug.Log(speed);

        //前フレーム位置を取得
        _prevPosition = position;
    }

    public static float CubeSpeed()
    {
        return speed;
    }
}
