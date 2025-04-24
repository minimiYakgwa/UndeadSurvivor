using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    // Player 이동값
    public Vector2 inputVec;
    [SerializeField]
    private float playerSpeed;

    // Player 필요 컴포넌트
    private Rigidbody2D playerRigid;
    private SpriteRenderer playerSprite;
    private Animator playerAnim;

    

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * playerSpeed * Time.fixedDeltaTime;
        playerRigid.MovePosition(nextVec + playerRigid.position);
    }

    private void LateUpdate()
    {
        playerAnim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            playerSprite.flipX = inputVec.x < 0;
        }
    }
}
