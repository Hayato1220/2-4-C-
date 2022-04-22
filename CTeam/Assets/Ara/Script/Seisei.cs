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

    public bool Bynok;

    public bool BynokTarget1;

    public bool BynokTarget2;

    public bool BynokTarget3;

    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;

        ok = false;

        Bynok = false;

        BynokTarget1 = false;
        BynokTarget2 = false;
        BynokTarget3 = false;
    }

    // Update is called once per frame
    void Update()
    {

        Bynok = KesuAra.Bynkie();

        BynokTarget1 = CreateTarget1.Getok1();
        BynokTarget2 = CreateTarget2.Getok2();
        BynokTarget3 = CreateTarget3.Getok3();


        if (Bynok == true || BynokTarget1 == true || BynokTarget2 == true || BynokTarget3 == true)
        {
            cubecount = 0;
        }

        if (ok == true)
        {

            while (cubecount < 2)
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
