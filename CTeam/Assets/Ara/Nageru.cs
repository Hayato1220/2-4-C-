using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nageru : MonoBehaviour
{
    public Transform oya;

    // Start is called before the first frame update
    void Start()
    {
        oya = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                this.transform.parent = GameObject.Find("WeponBoal").transform;

                this.transform.localPosition = new Vector3(0.09f, -0.06f, 0f);
            }
        }
    }
}
