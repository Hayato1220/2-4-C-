using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ByunEffect : MonoBehaviour
{
    private GameObject byun_P;
    private GameObject byun_P2;

    private GameObject childObjbyun;
    private GameObject childObjbyun2;

    Ray ray;
    RaycastHit hit;

    Ray ray2;

    void Start()
    {
        byun_P = Resources.Load("ByunTrail") as GameObject;
        childObjbyun = (GameObject)Instantiate(byun_P, this.transform.position, Quaternion.identity);
        childObjbyun.transform.parent = this.gameObject.transform;

        byun_P2 = Resources.Load("byunEffect") as GameObject;

    }

    void Update()
    {
        /* 追尾するエフェクトが床についていていらた表示しないようにする */
        ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            childObjbyun.SetActive(false);
            //Debug.Log(hit.collider.gameObject.transform.position);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
        }
        else
        {
            childObjbyun.SetActive(true);
            //if (Input.GetButtonDown("B"))
            //{
            //    childObjbyun2.SetActive(true);
            //}
        }


        //ray2 = new Ray(transform.position, -transform.forward);
        //    if (Physics.Raycast(ray2, out hit, 0.5f))
        //    {
        //        if (hit.collider.CompareTag("Player"))
        //        {
        //            if (Input.GetButtonDown("B"))
        //            {
        //                var playerfor = hit.collider.gameObject.transform.forward;
        //                childObjbyun2 = (GameObject)Instantiate(byun_P2, hit.collider.transform.position + hit.collider.transform.forward * 0.5f, Quaternion.identity);
        //                childObjbyun2.transform.parent = hit.collider.gameObject.transform;
        //                Destroy(childObjbyun2, 1.0f);
        //            }
        //        }
        //    }
        //    Debug.DrawRay(ray2.origin, ray2.direction, Color.red, 3.0f);
        //}


        /*
         * Physics.BoxCast(ボックスの位置(center), 各軸についてのボックスサイズの半分(中心座標から 0.5f と考えると分かりやすい,
         *                 Cast を飛ばす向き(その方向に対して永遠に伸ばし続ける), 
         *                 hit は Cast に当たった相手の情報を取る, ボックスの回転, Cast の最大の長さ
         *                 その他後ろはリファレンス参照
         */
        // プレイヤーがボックスに触れて飛ばすときに一回だけ発動させたい
        // 今のところプレイヤーが触れなくて出る、最初の一回目はエフェクトが出ない、
        //if (Physics.BoxCast(transform.position, Vector3.one, -transform.forward, out hit, Quaternion.identity))
        //{
        //    //Debug.Log(hit.transform.name);
        //    if (hit.collider.CompareTag("Player"))
        //    {
        //        if (Input.GetButtonDown("B"))
        //        {
        //            Debug.Log(hit.transform.name);
        //            //var playerfor = hit.collider.gameObject.transform.forward;
        //            childObjbyun2 = (GameObject)Instantiate(byun_P2, hit.collider.transform.position + hit.collider.transform.forward * 0.5f, Quaternion.identity);
        //            childObjbyun2.transform.parent = hit.collider.gameObject.transform;
        //            Destroy(childObjbyun2, 1.0f);
        //        }
        //    }
        //}
    }

    void OnDrawGizmos()
    {
        //　Cubeのレイを疑似的に視覚化
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}

