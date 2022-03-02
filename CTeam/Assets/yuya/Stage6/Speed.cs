//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Speed : MonoBehaviour
//{
//    public GameObject DestroyWall;

//    private Rigidbody rb;

//    void Start()
//    {
//        rb = this.transform.GetComponent<Rigidbody>();
//    }

//    void Update()
//    {



//        Debug.Log(rb.velocity.magnitude);



//        deltaTimeが0の場合は何もしない
//        if (Mathf.Approximately(Time.deltaTime, 0))
//        {
//            return;
//        }

//        //現在位置取得
//        var position = transform.position;

//        //現在速度計算
//        var speed = (position - _prevPosition) / Time.deltaTime;

//        speed.x += speed.x;

//        //現在速度をログ出力
//        //Debug.Log(speed.x);

//        //前フレーム位置を取得
//        _prevPosition = position;
//    }

//    void OnCollisionEnter(Collision other)
//    {
//        if (other.gameObject.tag == "Wall")
//        {

//            if (rb.velocity.magnitude >= 3.0f)
//            {

//                Destroy(DestroyWall);

//                Destroy(this.gameObject);
//            }
//        }
//    }
//}
