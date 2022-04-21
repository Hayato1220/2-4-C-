using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seisei : MonoBehaviour
{
    public GameObject obj;

    public bool ok;

    public Vector3 targetpos;

    [SerializeField]
    public float Speed = 0.01f;

    public static int cubecount = 0;

    public static bool Bynok;

    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;

        ok = false;

        Bynok = false;
    }

    // Update is called once per frame
    void Update()
    {

        Bynok = KesuAra.Bynkie();

        if(Bynok == true)
        {
            cubecount = 0;
        }

        if (ok == true)
        {
            while(cubecount < 2)
            {
                SeiBrock();
                cubecount++;
            }

            if (targetpos.x >= -8.3f)
            {
                targetpos.x -= Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }
        }
        else if(ok == false)
        {
            if(targetpos.x < -8f)
            {
                targetpos.x += Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButton("A"))
            {
                ok = true;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ok = false;
        }
    }

    void SeiBrock()
    {
        Instantiate(obj, new Vector3(-6, 5, 96), Quaternion.identity);
    }

    public static int okcount()
    {
        return cubecount;
    }
}
