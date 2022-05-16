using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyGionChange : MonoBehaviour
{
    public Text changetext;     //切り替えによって擬音が変わるテキストを入れる用変数

    int getnumber;              // Gion スクリプトから number を受け取る用変数


    void Update()
    {
        getnumber = CopyGion.ChangeNumber();        // Gion スクリプトから number を受け取る

        switch (getnumber)
        {
            case 0:
                changetext.text = "すべすべ";
                break;

            case 1:
                changetext.text = "ふわふわ";
                break;

            case 2:
                changetext.text = "すけすけ";
                break;

            case 3:
                changetext.text = "びゅんびゅん";
                break;

            case 4:
                changetext.text = "ばらばら";
                break;

            case 5:
                changetext.text = "ねばねば";
                break;

        }
    }
}
