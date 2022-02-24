using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    //ドアのアニメーター
    [SerializeField]
    [Tooltip("自動ドアのアニメーター")]
    private Animator automaticDoorAnimator;

    ///<summary>
    ///自動ドア検知エリアに入った時
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Object")
        {
            //アニメーションパラメータをtrueにする（ドアが開く)
            automaticDoorAnimator.SetBool("Open", true);
        }
    }

    ///<summary>
    ///自動ドア検知エリアを出た時
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Object")
        {
            //アニメーションパラメータをfalseにする（ドアが閉まる)
            automaticDoorAnimator.SetBool("Open", false);
        }
    }
}
