using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moyouGreen : MonoBehaviour
{
    public GameObject spot;

    private static bool dousyoku;

    void Start()
    {
        dousyoku = false;

        spot.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Green")
        {
            dousyoku = true;

            spot.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Green")
        {
            spot.SetActive(false);

            dousyoku = false;
        }
    }

    public static bool Green()
    {
        return dousyoku;
    }
}
