using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SubeEffect : MonoBehaviour
{
    private int objCount;

    private GameObject sube_P;

    private GameObject childObjsube;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        sube_P = Resources.Load("SubeBubbles") as GameObject;

        Debug.Log("すべすべエフェクトを追加");
        childObjsube = (GameObject)Instantiate(sube_P, this.transform.position + this.transform.up * -0.5f, Quaternion.identity);
        childObjsube.transform.parent = this.gameObject.transform;
    }



    void Update()
    {
        ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            childObjsube.SetActive(true);
            //Debug.Log(hit.collider.gameObject.transform.position);
            //Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
        }
        else
        {
            childObjsube.SetActive(false);
        }
    }
}
