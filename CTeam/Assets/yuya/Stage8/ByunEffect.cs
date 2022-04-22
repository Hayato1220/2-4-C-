//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[DisallowMultipleComponent]
//public class ByunEffect : MonoBehaviour
//{
//    private GameObject byun_P;

//    void Start()
//    {
//        byun_P = Resources.Load("ByunTrail") as GameObject;
//    }

//    void Update()
//    {

//    }

//    void OnCollisionStay(Collision other)
//    {
//        if (this.transform.GetChild(0).gameObject.name != "ByunTrail(Clone)")
//        {
//            childObjbyun = (GameObject)Instantiate(byun_P, this.transform.position, Quaternion.identity);
//            childObjbyun.transform.parent = this.gameObject.transform;
//        }
//    }
//}

