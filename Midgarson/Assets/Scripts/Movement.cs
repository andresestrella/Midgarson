using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 8f;
    [SerializeField]
    private float jumpForce = 5f;
    private float movementX, movementX2;
    private bool jump,bend;
    private bool isGrounded;
    private Rigidbody2D myBody;
    private SpriteRenderer mySprite;

    private string WALK_ANIMATION = "Walk";
    private string RUN_ANIMATION = "Run";
    private string JUMP_ANIMATION = "Jump";
    private string BEND_ANIMATION = "Bend";
    private Animator anim;

    [SerializeField]
    private float nitro = 14f;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        PlayerMoveKeyboard();
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementX2 = Input.GetAxisRaw("Fire3");
        jump = Input.GetButtonDown("Jump");
        bend = Input.GetButtonDown("Fire1");

        anim.SetBool(WALK_ANIMATION, movementX != 0.0f && movementX2 == 0f);
        anim.SetBool(RUN_ANIMATION, movementX != 0.0f && movementX2 != 0f);
        anim.SetBool(BEND_ANIMATION, movementX == 0.0f && movementX2 == 0f && bend);
        anim.SetBool(JUMP_ANIMATION, false);
       
        if (jump && isGrounded)
        {  
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIMATION, true);
            isGrounded = false;
        }

        if (movementX != 0f && movementX2 == 0f)
        {
            moveForce = 8f;
        }

        if (movementX2 != 0f)
        {
            moveForce = nitro;
        }

        if (movementX < 0)
        { 
            mySprite.flipX = true;
        }
        else if (movementX > 0)
        { 
           mySprite.flipX = false;
        }

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
