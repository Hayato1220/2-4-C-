using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByunEffect : MonoBehaviour
{
    private TrailRenderer _trail;
    int getChangenumber;

    void Start()
    {
        _trail = GetComponent<TrailRenderer>();
        _trail.enabled = false;
    }

    void Update()
    {
        getChangenumber = CopyGion.ChangeNumber();
    }

    void OnCollisionStay(Collision collision)
    {
        if (getChangenumber == 4)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                _trail.enabled = false;
            }
            else
            {
                _trail.enabled = true;
            }
        }
    }
}

