using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSitchAra : MonoBehaviour
{
    public bool getSitch;

    Vector3 targetpos;

    [SerializeField]
    public float Speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        getSitch = false;

        targetpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        getSitch = SitchAra.OKsitch();

        if(getSitch == true)
        {
            if(targetpos.y <= 11.5f)
            {
                targetpos.y += Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }
        }

        if (getSitch == false)
        {
            if (targetpos.y > 10.5f)
            {
                targetpos.y -= Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }
        }
    }
}
