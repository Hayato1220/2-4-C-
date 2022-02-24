using UnityEngine;
using System.Collections;

public class Push : MonoBehaviour
{

	//　右肩からRayを出す位置
	[SerializeField]
	private Transform rightRayTransform;
	//　左肩からRayを出す位置
	[SerializeField]
	private Transform leftRayTransform;
	//　右手が物を触っているか
	private bool isTouchRight = false;
	//　左手が物を触っているか
	private bool isTouchLeft = false;
	//　右手の位置
	private Vector3 rightHandPosition;
	//　右手の角度
	private Quaternion rightHandRotation;
	//　左手の位置
	private Vector3 leftHandPosition;
	//　左手の角度
	private Quaternion leftHandRotation;
	private Animator animator;
	//　右手のIKのウエイト
	private float rightHandWeight = 0f;
	//　左手のIKのウエイト
	private float leftHandWeight = 0f;
	//　手を付けるスピード
	[SerializeField]
	private float touchSpeed = 1.5f;

	[SerializeField]
	private float removeSpeed = 3f;
	//　押す力
	[SerializeField]
	private float pushPower = 2000f;
	//　レイの距離
	[SerializeField]
	private float rayDistance = 0.7f;
	//　壁と手の間のオフセット値
	[SerializeField]
	private float wallHandOffset = 0.1f;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		//　確認の為手を付く場所へレイを確認
		Debug.DrawRay(rightRayTransform.position, rightRayTransform.forward * rayDistance, Color.yellow);
		Debug.DrawRay(leftRayTransform.position, leftRayTransform.forward * rayDistance, Color.yellow);

		RaycastHit hit;

		//　右肩からレイを飛ばし、Blockにヒットしているかどうか
		if (Physics.Raycast(rightRayTransform.position, rightRayTransform.forward, out hit, rayDistance, LayerMask.GetMask("Block")))
		{
			rightHandPosition = hit.point + hit.normal * wallHandOffset;
			rightHandRotation = Quaternion.FromToRotation(Vector3.up, hit.normal) * transform.rotation;
			isTouchRight = true;
		}
		else
		{
			isTouchRight = false;
		}

		//　左肩からレイを飛ばし、Blockにヒットしているかどうか

		if (Physics.Raycast(leftRayTransform.position, leftRayTransform.forward, out hit, rayDistance, LayerMask.GetMask("Block")))
		{
			leftHandPosition = hit.point + hit.normal * wallHandOffset;
			leftHandRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
			isTouchLeft = true;
		}
		else
		{
			isTouchLeft = false;
		}

		//　右手用のウエイトを変化させる
		if (isTouchRight)
		{
			if (rightHandWeight < 1f)
			{
				rightHandWeight = Mathf.MoveTowards(rightHandWeight, 1f, touchSpeed * Time.deltaTime);
			}
		}
		else
		{
			rightHandWeight = Mathf.MoveTowards(rightHandWeight, 0f, removeSpeed * Time.deltaTime);
		}
		//　左手用のウエイトを変化させる
		if (isTouchLeft)
		{
			if (leftHandWeight < 1f)
			{
				leftHandWeight = Mathf.MoveTowards(leftHandWeight, 1f, touchSpeed * Time.deltaTime);
			}
		}
		else
		{

			leftHandWeight = Mathf.MoveTowards(leftHandWeight, 0f, removeSpeed * Time.deltaTime);
		}
	}

	//　CharacterControllerが他のコライダと接触している
	void OnControllerColliderHit(ControllerColliderHit col)
	{
		//　ぶつかっている相手がBlockだったらキャラクターの方向に力を加える
		if (col.gameObject.layer == LayerMask.NameToLayer("Block"))
		{
			col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushPower);
		}
	}

	void OnAnimatorIK()
	{
        //　右手のIKのウエイト設定
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);
        //　左手のIKのウエイト設定
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        //　右手の位置設定
        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandPosition);
		animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandRotation);
		//　左手の位置設定
		animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPosition);
		animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandRotation);
	}

}
