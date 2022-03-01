using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    public GameObject box;      //正四角形のオブジェクト
    public GameObject floor;    //滑らせる床


    private BoxCollider boxcollider;    //正四角形のオブジェクトのコライダー
    private BoxCollider floorcollider;  //滑らせる床のコライダー


    public PhysicMaterial slip;     //摩擦を無くすPhysicMaterialを入れる変数


    static private bool Apush = false;  //後々使うかも（消してもいい）



    void Start()
    {
        floorcollider = floor.GetComponent<BoxCollider>();  //正四角形のコライダー取得
        boxcollider = box.GetComponent<BoxCollider>();      //滑らせる床のコライダー取得
    }



    //このスクリプトがアタッチされているオブジェクトが他のオブジェクトに衝突している間
    void OnCollisionStay(Collision other)
    {
        //衝突したGameObjectのタグが"Floor"なら
        if(other.gameObject.tag == "Floor")
        {
            //"B"ボタンを押すと
            if (Input.GetButton("B"))
            {
                floorcollider.material = slip;  //滑らせる床のMaterialをslip変数に入っているMaterialに変える
                boxcollider.material = slip;    //正四角形のMaterialをslip変数に入っているMaterialに変える
                Apush = true;
            }
        }
    }



    //後々使うかも(消してもいい）
    static public bool Apushflag()
    {
        return Apush;
    }
}
