using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GionChangeText : MonoBehaviour
{
    public Text changetext;     //切り替えによって擬音が変わるテキストを入れる用変数

    int getnumber;              // Gion スクリプトから number を受け取る用変数


    void Update()
    {
        getnumber = Gion.ChangeNumber();        // Gion スクリプトから number を受け取る

        switch (getnumber)
        {
            case 0:
                changetext.text = "擬音:すべすべ";
                break;

            case 1:
                changetext.text = "擬音:ふわふわ";
                break;

            case 2:
                changetext.text = "擬音:バラバラ";
                break;

            case 3:
                changetext.text = "擬音:スケスケ";
                break;

            case 4:
                changetext.text = "擬音:ビュンビュン";
                break;
        }
    }
}
