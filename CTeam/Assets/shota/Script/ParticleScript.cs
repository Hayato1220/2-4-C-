using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public GameObject particleObject;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Object") //Objectタグの付いたゲームオブジェクトとふれている間判別
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
        }
    }
}