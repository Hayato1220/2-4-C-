using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubeEffect : MonoBehaviour
{
    private static bool layerflag;

    void Start()
    {
        layerflag = false;
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            layerflag = true;
        }
        else
        {
            layerflag = false;
        }
    }

    public static bool getflagLayer()
    {
        return layerflag;
    }
}
