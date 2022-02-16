using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("A"))
        {
            Debug.Log("Aボタンが押されました。");
        }

        if (Input.GetButton("B"))
        {
            Debug.Log("Bボタンが押されました。");
        }

        if (Input.GetButton("X"))
        {
            Debug.Log("Xボタンが押されました。");
        }

        if (Input.GetButton("Y"))
        {
            Debug.Log("Yボタンが押されました。");
        }

        //float L_stick_H = Input.GetAxis("L_Stick_H");
        //float L_stick_V = Input.GetAxis("L_Stick_V");

        //if(L_stick_H >= 0)
        //{
        //    Debug.Log("Lスティックを横方向に入力しました。");
        //}

        //if(L_stick_V >= 0)
        //{
        //    Debug.Log("Lスティックを縦方向に入力しました。");
        //}

        if (Input.GetAxis("L_Stick_H") == -1)
        {
            Debug.Log("Lスティック(左）が入力されました。");
        }else if(Input.GetAxis("L_Stick_H") == 1)
        {
            Debug.Log("Lスティック（右）が入力されました。");
        }

        if(Input.GetAxis("L_Stick_V") == -1)
        {
            Debug.Log("Lスティックが上方向に入力されました。");
        }else if (Input.GetAxis("L_Stick_V") == 1)
        {
            Debug.Log("Lスティックが下方向に入力されました。");
        }
    }
}
