using UnityEngine;

public class Byun : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		// 力を加える向きをVector3型で定義
		// 今回はX軸から45度の向きに射出するため、XとYを1:1にする
		Vector3 forceDirection = new Vector3(0f, 1.0f, 1.0f);

		// 上の向きに加わる力の大きさを定義
		float forceMagnitude = 100.0f;

		// 向きと大きさからSphereに加わる力を計算する
		Vector3 force = forceMagnitude * forceDirection;

		// SphereオブジェクトのRigidbodyコンポーネントへの参照を取得
		Rigidbody rb = gameObject.GetComponent<Rigidbody>();

		// 力を加えるメソッド
		// ForceMode.Impulseは撃力
		rb.AddForce(force, ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update()
	{

	}
}