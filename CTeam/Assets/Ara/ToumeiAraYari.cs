using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToumeiAraYari : MonoBehaviour
{
    MeshRenderer mr;

    public bool ok;

    public static bool yumi;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();

        mr.material.color = mr.material.color - new Color32(0, 0, 0, 0);

        ok = false;

        yumi = false;
    }

    void Update()
    {
        if (ok == true)
        {
            if (Input.GetButton("B"))
            {
                mr.material.color = mr.material.color - new Color32(0, 0, 0, 1);
            }
        }
        if (mr.material.color.a <= 0)
        {
            Destroy(this.gameObject);

            yumi = true;
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ok = true;

        }
    }

    public static bool yari()
    {
        return yumi;
    }
}
