using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFencesAra2 : MonoBehaviour
{
    Vector3 targetpos;

    [SerializeField]
    public float Speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;
    }

    void Update()
    {
        if (targetpos.x <= 13.2f)
        {
            targetpos.x += Speed;
            transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
        }
    }
}
