using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neba : MonoBehaviour
{
    private GameObject neba_P;

    private GameObject childObjneba;
    void Start()
    {
        neba_P = Resoursces.Load("NebaEffect") as GameObject;
        childObjneba = (GameObject)Instantiate(neba_P, this.transform.position, Quaternion.identity);
        childObjneba.transform.parent = this.gameObject.transform;
    }

    void Update()
    {
        
    }
}
