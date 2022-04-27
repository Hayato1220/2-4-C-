using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    //最大HPと現在のHP。
    float maxHp = 100f;
    float currentHp;
    //Sliderを入れる
    public Slider slider;

    public static bool okDamaged;

    public GameObject player;

    public Vector3 SavePoint;

    //public Image image;
    //private float time;
    //public float speed = 10.0f;


    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        Debug.Log("Start currentHp : " + currentHp);

        okDamaged = false;

        SavePoint.z = 0f;

        SavePoint.y = 0f;

        //image = image.GetComponent<Image>();

        //image.color = Color.clear;

    }

    void Update()
    {
        //if (okDamaged == true)
        //{
        //    image.color = new Color(1f, 0, 0, 0.5f);
        //    image.color = GetAlphaColor(image.color);
        //}

        //else if (okDamaged == false)
        //{
        //    image.color = Color.clear;
        //}
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    void OnTriggerEnter(Collider collider)
    {
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "Enemy")
        {
            okDamaged = true;

            player.SetActive(false);

            Invoke("SeiPlayer", 1f);

            float damage = 10f;
            Debug.Log("damage : " + damage);

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + currentHp);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = currentHp / maxHp; 
            Debug.Log("slider.value : " + slider.value);

        }

        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "EnemyBullet")
        {
            okDamaged = true;

            Invoke("TenmetuNo", 1f);

            float damage = 10f;
            Debug.Log("damage : " + damage);

            currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + currentHp);

            slider.value = currentHp / maxHp;
            Debug.Log("slider.value : " + slider.value);

        }

        if (collider.gameObject.tag == "Save")
        {
            SavePoint.z = collider.gameObject.transform.position.z;

            SavePoint.y = collider.gameObject.transform.position.y;
        }
    }

    void SeiPlayer()
    {
        player.transform.position = new Vector3(8f, SavePoint.y, SavePoint.z);
        player.SetActive(true);
        okDamaged = false;
    }

    public static bool Damaged()
    {
        return okDamaged;
    }

    void TenmetuNo()
    {
        okDamaged = false;
    }

    //Color GetAlphaColor(Color color)
    //{
    //    time += Time.deltaTime * 5.0f * speed;
    //    color.a = Mathf.Sin(time) * 0.5f + 0.1f;

    //    return color;
    //}
}
