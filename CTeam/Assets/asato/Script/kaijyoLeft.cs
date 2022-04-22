using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaijyoLeft : MonoBehaviour
{
    [SerializeField]
    public float Speed = 0.01f;

    Vector3 targetpos;


    private bool ok;

    private bool getRed;
    private bool getGreen;
    private bool getBlue;
    private bool getWhite;
    public bool getAll;


    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;

        ok = false;

        getAll = false;
    }

    // Update is called once per frame
    void Update()
    {
        getRed = moyouRed.Red();

        getGreen = moyouGreen.Green();

        getBlue = moyouBlue.Blue();

        getWhite = moyouWhite.White();

        if (getRed == true && getGreen == true && getBlue == true && getWhite == true)
        {
            getAll = true;
        }

        if (getAll == true)
        {
            if(targetpos.x >= 2f)
            {
                targetpos.x -= Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }
            if(targetpos.x <= 2f)
            {
                Destroy(gameObject);
            }
        }
    }
}
