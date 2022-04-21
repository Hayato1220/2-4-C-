using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SubeEffect : MonoBehaviour
{
    private int objCount;

    private GameObject sube_P;


    //private GameObjct obj;

    void Start()
    {
        sube_P = Resources.Load("SubeBubbles") as GameObject;
    }

    void Update()
    {
        objCount = this.gameObject.transform.childCount;

        //if (objCount == 0)
        //{

        //}

        //if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        //{
        //    Debug.Log("すべすべエフェクト追加前");
        //    if (this.transform.GetChild(0).gameObject.name != "SubeBubbles(Clone)")
        //    {
        //        Debug.Log("すべすべエフェクトを追加");
        //        var childObjsube = (GameObject)Instantiate(sube_P, this.transform.position + this.transform.up * -0.5f, Quaternion.identity);
        //        childObjsube.transform.parent = this.gameObject.transform;
        //    }
        //}
    }

    //名前だと先に処理してしまって参照が出来ず、エラーが起きる
    //CopyGionから別のスクリプトを付与して、SubeEffectでエフェクトを制御しようとしてる
    //パーティクルを付けて、違うパーティクルを付けるときに消してしまうようになっているので改善が必要
    void OnCollisionStay(Collision other)
    {
        if (this.transform.GetChild(0).gameObject.name != "SubeBubbles(Clone)")
        {
            Debug.Log("すべすべエフェクトを追加");
            var childObjsube = (GameObject)Instantiate(sube_P, this.transform.position + this.transform.up * -0.5f, Quaternion.identity);
            childObjsube.transform.parent = this.gameObject.transform;
        }

    }
}
