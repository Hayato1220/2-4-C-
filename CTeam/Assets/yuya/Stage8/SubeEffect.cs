using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SubeEffect : MonoBehaviour
{
    private int objCount;

    private GameObject sube_P;

    private GameObject childObjsube;

    void Start()
    {
        sube_P = Resources.Load("SubeBubbles") as GameObject;

        Debug.Log("すべすべエフェクトを追加");
        childObjsube = (GameObject)Instantiate(sube_P, this.transform.position + this.transform.up * -0.5f, Quaternion.identity);
        childObjsube.transform.parent = this.gameObject.transform;
    }

    void Update()
    {
        objCount = this.gameObject.transform.childCount;
    }
}
