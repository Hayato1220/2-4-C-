using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public bool getAll;

    Vector3 targetpos;

    [SerializeField]
    public float Speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        getAll = TobiraBreak.Move();

        if(getAll == true)
        {
            if (targetpos.y <= 8.5f)
            {
                targetpos.y += Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }

            if(targetpos.y >= 8.4f && targetpos.z <= 3.4f)
            {
                targetpos.z += Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }
        }
    }
}
