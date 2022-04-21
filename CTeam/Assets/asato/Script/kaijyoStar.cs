using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaijyoStar : MonoBehaviour
{
    [SerializeField]
    public float Speed = 0.02f;

    [SerializeField]
    public Vector3 Rote;

    Vector3 targetpos;

    public Material material;

    Renderer rend;


    private bool ok;

    private bool getRed;
    private bool getGreen;
    private bool getBlue;
    private bool getWhite;

    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;

        rend = gameObject.GetComponent<Renderer>();
        ok = false;
    }

    // Update is called once per frame
    void Update()
    {
        getRed = moyouRed.Red();

        getGreen = moyouGreen.Green();

        getBlue = moyouBlue.Blue();

        getWhite = moyouWhite.White();

        if (getRed == true/* && getGreen == true && getBlue == true && getWhite == true*/)
        {
            if (targetpos.z >= 148.5f)
            {
                targetpos.z -= Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }

            if (targetpos.z <= 148.6f)
            {

                if (targetpos.y <= 8f)
                {
                    targetpos.y += Speed;
                    transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
                }
                if (targetpos.y >= 8f)
                {
                    rend.material = material;
                }
            }
            transform.Rotate(Rote);

        }
    }
}
