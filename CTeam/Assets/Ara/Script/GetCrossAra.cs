using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCrossAra : MonoBehaviour
{

    public static bool getcross;

    // Start is called before the first frame update
    void Start()
    {
        getcross = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            getcross = true;
        }
    }

    public static bool CrossGet()
    {
        return getcross;
    }


}
