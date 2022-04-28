using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BaraEffect : MonoBehaviour
{
    private GameObject bara_P;

    private GameObject childObjbara;

    void Start()
    {
        bara_P = Resources.Load("BaraEffect") as GameObject;
        childObjbara = (GameObject)Instantiate(bara_P, this.transform.position, Quaternion.identity);
        childObjbara.transform.parent = this.gameObject.transform;
    }

    void Update()
    {

    }
}
