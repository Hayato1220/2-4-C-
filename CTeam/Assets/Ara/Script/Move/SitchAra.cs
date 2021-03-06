using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitchAra : MonoBehaviour
{

    Vector3 targetpos;

    [SerializeField]
    public float Speed = 0.01f;

    public static bool Onsitch;

    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip Button;

    // Start is called before the first frame update
    void Start()
    {
        Onsitch = false;

        targetpos = transform.position;

        audioS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Onsitch == false)
        {
            if (targetpos.y < 8f)
            {
                targetpos.y += Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);

            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Onsitch = true;
            if (targetpos.y >= 7.6f)
            {
                targetpos.y -= Speed;
                transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioS.PlayOneShot(Button);

        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Onsitch = false;

        }
    }

    public static bool OKsitch()
    {
        return Onsitch;
    }

}
