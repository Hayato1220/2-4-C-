using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ByunEffect : MonoBehaviour
{
    private GameObject byun_P;

    private GameObject childObjbyun;

    void Start()
    {
        byun_P = Resources.Load("ByunTrail") as GameObject;
        childObjbyun = (GameObject)Instantiate(byun_P, this.transform.position, Quaternion.identity);
        childObjbyun.transform.parent = this.gameObject.transform;
    }
}

