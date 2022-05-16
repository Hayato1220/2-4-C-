using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moyouRed : MonoBehaviour
{
    public GameObject spot;

    private static bool dousyoku;

    // Start is called before the first frame update
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
        if (other.gameObject.tag == "Red")
        {
            spot.SetActive(true);


            dousyoku = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Red")
        {
            spot.SetActive(false);

            dousyoku = false;
        }
    }

    public static bool Red()
    {
        return dousyoku;
    }
}
