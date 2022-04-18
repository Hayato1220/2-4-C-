using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget2 : MonoBehaviour
{
    public GameObject batu;
    public GameObject maru;
    public GameObject cube;

    public static bool target2;

    // Start is called before the first frame update
    void Start()
    {
        target2 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            batu.SetActive(false);
            maru.SetActive(true);
            Destroy(cube);

            target2 = true;
        }
    }

    public static bool GetTarget2()
    {
        return target2;
    }
}
