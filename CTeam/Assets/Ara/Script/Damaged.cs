using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damaged : MonoBehaviour
{

    //public
    public float speed = 10.0f;
    public bool getDamaged;

    //private
    private Image image;
    private float time;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.clear;
        getDamaged = false;
    }

    void Update()
    {
        getDamaged = HP.Damaged();

        if (getDamaged == true)
        {
            image.color = new Color(1f, 0, 0, 0.5f);
            image.color = GetAlphaColor(image.color);
        }

        else if (getDamaged == false)
        {
            image.color = Color.clear;
        }

    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
