using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byun : MonoBehaviour
{

	// 飛行中フラグ
	bool isFlying = false;

	// ボタン押下フラグ
	bool isBoostPressed = false;

	// Sphereオブジェクトの初期位置格納用ベクトル
	Vector3 initPosition = Vector3.zero;

	void Start()
	{
		initPosition = gameObject.transform.position;
	}

	void Update()
	{
		// Input.GetKeyUpはキーが一度押された後、それが離された時にTrueを返す
		if (Input.GetKeyUp(KeyCode.Space))
		{
			isBoostPressed = true;
		}
	}

	void FixedUpdate()
	{
		if (isBoostPressed)
		{
			if (isFlying)
			{
				// 飛行中の処理

				// 運動の停止
				Rigidbody rb = gameObject.GetComponent<Rigidbody>();
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;

				// 初期位置に移動させる
				gameObject.transform.position = initPosition;
			}
			else
			{
				// ボールを飛ばす処理

				// 力を加える方向
				Vector3 forceDirection = new Vector3(1.0f, 1.0f, 0f);

				// 加える力の大きさ
				float forceMagnitude = 10.0f;

				// 向きと力の計算
				Vector3 force = forceMagnitude * forceDirection;

				// 力を加えるメソッド
				Rigidbody rb = gameObject.GetComponent<Rigidbody>();
				rb.AddForce(force, ForceMode.Impulse);
			}
			// 飛行中フラグの切り替え
			isFlying = !isFlying;

			// どちらの処理をしてもボタン押下フラグをfalseに
			isBoostPressed = false;
		}
	}
}