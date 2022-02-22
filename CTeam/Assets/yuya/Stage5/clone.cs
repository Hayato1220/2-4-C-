using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone : MonoBehaviour
{
    //オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject prefabObj;


    //生成したオブジェクトの親オブジェクトへの参照を保持します。
    public Transform parentTran;


    //マテリアルを保持します。
    public Material yellow;
    public Material Red;
    public Material blue;


    //Prefabを生成する高さを定義します。
    public float heigtht;

    void Start()
    {

    }

    void Update()
    {
        //フレームカウントが10の倍数の時にオブジェクトを生成します。
        if(Time.frameCount % 10 == 0)
        {
            CreateObject();
        }
    }


    //Prefabからオブジェクトを生成します。
    void CreateObject()
    {
        //ゲームオブジェクトを生成します
        GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);


        //ゲームオブジェクトの親オブジェクトを設定します。
        obj.transform.SetParent(parentTran);

        //ゲームオブジェクトの位置を設定します。
        obj.transform.localPosition = new Vector3(0f, height, 0f);

        //マテリアルをランダムで設定します。
        int materialId = Random.Range(0, 3);
    }
}
