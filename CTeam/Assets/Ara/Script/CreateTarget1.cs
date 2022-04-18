using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget1 : MonoBehaviour
{
    public GameObject batu;
    public GameObject maru;
    public GameObject cube;

    public static bool target1;

    // Start is called before the first frame update
    void Start()
    {
        target1 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            batu.SetActive(false);
            maru.SetActive(true);
            Destroy(cube);

            target1 = true;
        }
    }

    public static bool GetTarget1()
    {
        return target1;
    }
}
