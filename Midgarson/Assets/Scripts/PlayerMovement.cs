using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 8f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float walkingForce = 8f;
    [SerializeField]
    private float runningForce = 12f;
    private float movementX, yVelocity;
    private bool bend, isGrounded, isOnStairs;
    private Rigidbody2D myBody;
    private SpriteRenderer mySprite;

    private string WALK_ANIMATION = "Walk";
    private string RUN_ANIMATION = "Run";
    private string JUMP_ANIMATION = "Jump";
    private string FALL_ANIMATION = "Fall";
    private string ATTACK_ANIMATION = "Attack";

    private string HEAVY_ATTACK_ANIMATION = "HeavyAttack";
    private string SHOOTING_ANIMATION = "Shooting";
    private string THROWING_ANIMATION = "Throwing";
    private string STANDING_UP_ANIMATION = "StandingUp";
    private string HIT_ANIMATION = "Hit";

    //Sword Attack
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 30;
    public float attackRate = 2f;
    float nextAttackTime = 1f;

    //Axe Attack
    public Transform axeAttackPoint;
    public float axeAttackRange = 0.5f;
    public int axeAttackDamage = 60;
    public float axeAttackRate = 4f;
    float nextAxeAttackTime = 3f;


    //Bomb attack
    Vector3 startingSpeed = new Vector3(10f, 10f);
    float currentAngle, shootingAngle = 45;
    public GameObject bomb;

    //Arrow
    public GameObject arrow;
    Vector2 arrowPos;
    bool flip;

    //throwing Knife
    public float lastThrow = 0;
    public GameObject knife;
    Vector2 knifePos;
    bool _object;
    public LayerMask enemyLayers;

    private Animator anim;

    //Shield
    public GameObject shield;
    private bool shieldActive = false;
    private int selectedShield = 0;
    public ShieldDatabase shieldDB;

    //Items for gamestate
    public Item item1 = new Item(1, ItemTag.SHIELD, 1),
        item2 = new Item(2, ItemTag.KNIFE, 1),
        item3 = new Item(3, ItemTag.ARROW, 0),
        item4 = new Item(4, ItemTag.BOMB, 5);
    private Dictionary<ItemTag, Item> items = new Dictionary<ItemTag, Item>();

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        flip = false;


        if (!PlayerPrefs.HasKey("selectedShield"))
        {
            selectedShield = 0;
        }
        else
        {
            selectedShield = PlayerPrefs.GetInt("selectedShield");
        }

        UpdateShield(selectedShield);
    }

    void Update()
    {

        yVelocity = myBody.velocity.y;

        if (yVelocity < 0 && !isOnStairs && !isGrounded)
        {
            anim.SetBool(FALL_ANIMATION, true);
        }

        Attack();
        HeavyAttack();
        PlayerMoveKeyboard();
        WalkAnimation();
        Run();
        Jump();
        BowAttack();
        ThrowBomb();
        throwKnife();

        if (gameObject.GetComponent<PlayerLife>().currentShield > 0 && !shieldActive)
        {
            Instantiate(shield, gameObject.transform.position, Quaternion.identity).GetComponent<ShieldBehaviour>().Shoot(gameObject);
            shieldActive = true;
        }else if (gameObject.GetComponent<PlayerLife>().currentShield == 0)
        {
            GameObject shield = GameObject.FindGameObjectWithTag("ShieldItem");

            if(shield != null)
            {
                Destroy(shield);
            }
            
            shieldActive = false;
        }

    }

    private void Start()
    {
        items.Add(item1.tag, item1);
        items.Add(item2.tag, item2);
        items.Add(item3.tag, item3);
        items.Add(item4.tag, item4);
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        bend = Input.GetButtonDown("Fire1");

        /*anim.SetBool(WALK_ANIMATION, movementX != 0.0f && movementX2 == 0f);
         anim.SetBool(RUN_ANIMATION, movementX != 0.0f && movementX2 != 0f);
        anim.SetBool(BEND_ANIMATION, movementX == 0.0f && movementX2 == 0f && bend);
        anim.SetBool(JUMP_ANIMATION, false);*/


        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

        anim.SetFloat("yVelocity", yVelocity);
    }

    void WalkAnimation()
    {
        if (movementX > 0 && isGrounded)
        {
            if (flip)
            {
                shootingAngle = 45;
                flip = false;
                transform.Rotate(0f, 180f, 0);
            }

            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementX < 0 && isGrounded)
        {
            if (!flip)
            {
                shootingAngle = 135;
                transform.Rotate(0f, 180f, 0);
                flip = true;
            }
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool(JUMP_ANIMATION, true);
        }
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && movementX != 0 && isGrounded && yVelocity == 0)
        {
            moveForce = runningForce;
            anim.SetBool(RUN_ANIMATION, true);
        }
        if (Input.GetKey(KeyCode.LeftShift) && movementX != 0 && isGrounded && yVelocity == 0)
        {
            anim.SetBool(RUN_ANIMATION, true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveForce = walkingForce;
            anim.SetBool(RUN_ANIMATION, false);
        }
    }

    void Attack()
    {
        
        if (Input.GetMouseButtonDown(0) && isGrounded && nextAttackTime >= 0.7f){
            nextAttackTime = 0;
            anim.SetBool(ATTACK_ANIMATION, true);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<Enemy>().takeDamage(attackDamage);

            }
        }else {
            nextAttackTime += Time.deltaTime;
            anim.SetBool(ATTACK_ANIMATION, false);
        }
        
    }

    void HeavyAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isGrounded && nextAxeAttackTime >= 3f)
        {
            nextAxeAttackTime = 0;
            anim.SetBool(HEAVY_ATTACK_ANIMATION, true);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(axeAttackPoint.position, axeAttackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<Enemy>().takeDamage(axeAttackDamage);
            }
            
            nextAxeAttackTime = Time.time + 1f / axeAttackRate;
        }
        else
        {
            nextAxeAttackTime += Time.deltaTime;
            anim.SetBool(HEAVY_ATTACK_ANIMATION, false);
        }

        
    }

    void BowAttack()
    {
        if (Input.GetMouseButtonDown(1) && isGrounded)
        {
            anim.SetBool(SHOOTING_ANIMATION, true);
        }
        if (Input.GetMouseButtonUp(1) && isGrounded)
        {
            anim.SetBool(SHOOTING_ANIMATION, false);
        }
    }
    void _throw()
    {
        if(_object)
        {
            currentAngle = shootingAngle * Mathf.Deg2Rad;
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity).GetComponent<bombBehaviour>().Shoot(startingSpeed, currentAngle);
            
        }
        else
        {
            knifePos = gameObject.transform.position;
            knifePos.x += flip ? -0.5f : 0.5f;
            knifePos.y += 0.5f;
            Instantiate(knife, knifePos, Quaternion.identity).GetComponent<ArrowBehaviour>().shoot(flip, 0.4f);
        }
    }
    void ThrowBomb()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isGrounded && items[ItemTag.BOMB].count > 0)
        {
            anim.SetBool(THROWING_ANIMATION, true);
            _object = true;
            items[ItemTag.BOMB].count--;
        }
        if (Input.GetKeyUp(KeyCode.E) && isGrounded)
        {
            anim.SetBool(THROWING_ANIMATION, false);
            items[ItemTag.BOMB].count--;
        }
            
        

    }
    void throwKnife()
    {
        
            if (Input.GetKeyDown(KeyCode.T) && isGrounded && items[ItemTag.KNIFE].count > 0)
            {
                anim.SetBool(THROWING_ANIMATION, true);
                _object = false;

            }
            if (Input.GetKeyUp(KeyCode.T) && isGrounded)
            {
                anim.SetBool(THROWING_ANIMATION, false);

            }
            //items[ItemTag.KNIFE].count--;
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isOnStairs = false;
            anim.SetBool(JUMP_ANIMATION, false);
            anim.SetBool(FALL_ANIMATION, false);
            myBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (collision.gameObject.CompareTag("Stairs"))
        {
            isGrounded = true;
            isOnStairs = true;
            anim.SetBool(JUMP_ANIMATION, false);
            anim.SetBool(FALL_ANIMATION, false);
            myBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else if(collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.gameObject.transform;
            isGrounded = true;
            isOnStairs = false;
            anim.SetBool(JUMP_ANIMATION, false);
            anim.SetBool(FALL_ANIMATION, false);
            myBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (collision.gameObject.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);
            gameObject.GetComponent<PlayerLife>().AddHealth(20);
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            gameObject.GetComponent<PlayerLife>().AddShield(20);
        }
        else if (collision.gameObject.CompareTag("MinCoins"))
        {
            gameObject.GetComponent<PlayerLife>().sceneController.incrementCoins(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("MedCoins"))
        {
            gameObject.GetComponent<PlayerLife>().sceneController.incrementCoins(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("MaxCoins"))
        {
            gameObject.GetComponent<PlayerLife>().sceneController.incrementCoins(10);
            Destroy(collision.gameObject);
        }


    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Platform"){
            transform.parent = null;
        }
    }

    //Se llama a la función desde el animator al terminar la animacion
    //Esto se hace para que primero termine de animar y luego crear el objeto
    void shootArrow()
    {
        if(items[ItemTag.ARROW].count > 0)
        {
            arrowPos = gameObject.transform.position;
            arrowPos.y += 0.15f;
            Instantiate(arrow, arrowPos, Quaternion.identity).GetComponent<ArrowBehaviour>().shoot(flip, 0.5f);
            //items[ItemTag.KNIFE].count--;
        }

    }

    private void UpdateShield(int selectedOption)
    {
        Shield shieldScript = shieldDB.GetShield(selectedOption);
        
        if(shield != null)
        {
            shield.GetComponent<SpriteRenderer>().sprite = shieldScript.shieldSprite;
        }
    }

}
