//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class clone : MonoBehaviour
//{
//    //オブジェクトを生成する元となるPrefabへの参照を保持します。
//    public GameObject prefabObj;

//    public GameObject ParentObj;

//    //生成したオブジェクトの親オブジェクトへの参照を保持します。
//    public Transform parentTran;


//    //マテリアルを保持します。
//    public Material yellow;
//    public Material red;
//    public Material blue;

//    //Prefabを生成する高さを定義します。
//    public float height = 1.5f;

//    void Start()
//    {

//    }

//    void Update()
//    {

//    }

//    void OnCollisionStay(Collision other)
//    {
//        if (other.gameObject.tag == "Object")
//        {
//            if (Input.GetButton("B"))
//            {
//                CreateObject();

//            }

//        }
//    }


//    //Prefabからオブジェクトを生成します。
//    void CreateObject()
//    {

//        //ゲームオブジェクトを生成します
//        GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);

//        ////ゲームオブジェクトの親オブジェクトを設定します。
//        //obj.transform.SetParent(parentTran);

//        Transform parentObj = ParentObj.transform; //targetObjectに変更

//        //ゲームオブジェクトの位置を設定します。
//        obj.transform.position = parentObj.position;


//        //ゲームオブジェクトの親オブジェクトを設定します。
//        //obj.transform.SetParent(parentTran);

//        //ゲームオブジェクトの位置を設定します。
//        //obj.transform.position = new Vector3(0f, height, 0f);

//        //マテリアルをランダムで設定します。
//        //int materialId = Random.Range(0, 3);

//        //Destroy(OriginObj, 3f);
//    }
//}
