using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GionChangeText : MonoBehaviour
{
    public Text changetext;

    int getnumber;


    void Start()
    {

    }


    void Update()
    {
        getnumber = Gion.ChangeNumber();

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
