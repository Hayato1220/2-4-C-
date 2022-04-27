using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConAra : MonoBehaviour
{

    private CharacterController characterController;

    // Rigidbodyコンポーネント
    private Rigidbody rigidBody;
    //　キャラクターのコライダ
    private CapsuleCollider myCollider;
    // 入力値
    private Vector3 input;
    //　移動速度
    private Vector3 velocity;
    //　接地しているかどうか
    [SerializeField]
    private bool isGrounded;
    //　移動の速さ
    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private float jumpPower = 6f;

    [SerializeField]
    private float distanceToLanding = 2.5f;

    [SerializeField]
    public float distanceToTheGround = 2.5f;

    private Animator animator;

    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;

    Rigidbody m_Rigidbody;
    private Transform spine;
    public PhysicMaterial kabeslip;

    public bool IsDamaged;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        myCollider.material = null;

        IsDamaged = false;




        // get the transform of the main camera
        if (UnityEngine.Camera.main != null)
        {
            m_Cam = UnityEngine.Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }
    }

    // Update is called once per frame
    void Update()
    {
        //　接地確認
        CheckGround();
        ////　移動速度の計算
        //Move();

        //Jump();
    }


    //　地面のチェック
    private void CheckGround()
    {
        if (isGrounded)
        {
            return;
        }
        //　アニメーションパラメータのRigidbodyのYが0.1以下でGroundまたはEnemyレイヤーと球のコライダがぶつかった場合は地面に接地
        if (animator.GetFloat("JumpPower") <= 0.1f && Physics.CheckSphere(rigidBody.position, myCollider.radius - 0.1f, LayerMask.GetMask("Ground")) || animator.GetFloat("JumpPower") <= 0.1f && Physics.CheckSphere(rigidBody.position, myCollider.radius - 0.1f, LayerMask.GetMask("Block")))
        {
            isGrounded = true;
            velocity.y = 0f;

            //myCollider.material = null;
        }
        //      //　アニメーションパラメータFallがfalseの時で地面との距離が遠かったらFallをtrueにする
        //      else if (!animator.GetBool("Fall")) 
        //      {
        //          if (!Physics.SphereCast(new Ray(spine.position, Vector3.down), characterController.radius, distanceToTheGround, LayerMask.GetMask("Ground")))
        //          {
        //              animator.SetBool("Fall", true);
        //          }
        //}

        //      //　落下アニメーションの時はレイを飛ばし着地アニメーションにする
        //      else if (animator.GetBool ("Fall")) 
        //      {
        //          if (Physics.Linecast(spine.position, spine.position + Vector3.down * distanceToLanding, LayerMask.GetMask("Field")))
        //          {
        //              animator.SetBool("Landing", true);
        //          }
        //}
        else
        {
            isGrounded = false;

        }
        animator.SetBool("IsGrounded", isGrounded);
    }


    //　移動値と向きの計算
    private void Move()
    {
        //　接地している場合
        if (isGrounded)
        {
            //　移動速度の長さが0より大きければ歩くアニメーション
            if (velocity.magnitude > 0f)
            {
                animator.SetFloat("Speed", velocity.magnitude);
                
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
            //　移動速度を初期化
            velocity = Vector3.zero;
        }
        //else if (!isGrounded)
        //{
        //    animator.SetTrigger("Jump");
        //}

        float h = Input.GetAxis("L_Stick_H");

        float v = Input.GetAxis("L_Stick_V");

        m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;

        //　移動入力値
        input = v * m_CamForward + h * m_Cam.right;        //　速度の計算
        velocity = new Vector3(input.normalized.x * moveSpeed, 0f, input.normalized.z * moveSpeed);
    }


    //　ジャンプ処理
    private void Jump()
    {
        //　接地している場合
        if (isGrounded)
        {
            //　ジャンプ処理
            if (Input.GetButton("Y"))
            {
                GetComponent<AudioSource>().Play();  // 効果音を鳴らす
                isGrounded = false;
                animator.SetFloat("Speed", 0f);
                animator.SetBool("IsGrounded", isGrounded);
                //velocity.y += jumpPower;
                //rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y + jumpPower, rigidBody.velocity.z);
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpPower, rigidBody.velocity.z);
                animator.SetTrigger("Jump");
                Debug.Log("Jump!");
            }
        }
        //　ジャンプ力をアニメーションパラメータに設定
        animator.SetFloat("JumpPower", rigidBody.velocity.y);
    }

    //　ギズモの表示
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //　接地判断時の範囲表示
        Gizmos.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.down * 0.2f);
    }


    //　固定フレームレートで実行される
    private void FixedUpdate()
    {

        //　移動速度の計算
        Move();

        Jump();

        //　入力がある時だけ実行
        if (!Mathf.Approximately(input.x, 0f) || !Mathf.Approximately(input.z, 0f))
        {
            //　入力方向に向ける
            rigidBody.MoveRotation(Quaternion.LookRotation(input.normalized));
        }
        //// 入力がある時だけ実行
        //if (input.magnitude > 0f) {
        //	//　入力方向に向ける
        //	rigidBody.MoveRotation(Quaternion.LookRotation(input.normalized));
        //}


        //　現在の位置に1フレームの速度分を足して移動させる
        if (velocity.magnitude > 0f)
        {
            rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
        }

        //if (IsDamaged)
        //{
        //    float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        //    gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, level);
        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Block"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.forward, ForceMode.Acceleration);
        }

        if(collision.gameObject.tag == "Wall")
        {
            myCollider.material = kabeslip;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            myCollider.material = null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            IsDamaged = true;
        }
        if (collision.gameObject.tag == "Clear")
        {
            SceneManager.LoadScene("taitoru");
        }
    }

}
