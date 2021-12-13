using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerAnimationStates
    {
        IDLE, MOVING, JUMPING, HIT
    }

    [Header("Touch Input")]
    public Joystick joystick;
    [Range(0.01f, 1f)]
    public float sensitivity;

    [Header("Movement")]
    public float horizontalForce;
    public float verticalForce;
    [Range(0.1f, 0.99f)]
    public float airControlFactor = 0.5f;
    public bool isGrounded;

    private Rigidbody2D rigidbody;
    private Animator animator;

    public PlayerAnimationStates state;

    public Transform groundOrigin;
    public float groundRadius;
    public LayerMask groundLayerMask;

    [Header("Collision")]
    public UnityEvent OnCoinCollected;
    public UnityEvent OnHazardHit;
    bool invincible = false;
    float iframeTimer;
    [SerializeField]
    float iFrameDuration;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        CheckIfGrounded();

        UpdateIFrameTimer();
    }

    private void Move()
    {
        float x = (Input.GetAxisRaw("Horizontal") + joystick.Horizontal) * sensitivity;

        if (x != 0)
        {
            FlipAnimation(x);
        }

        if (isGrounded)
        {

            float y = (Input.GetAxisRaw("Vertical") + joystick.Vertical) * sensitivity;
            float jump = Input.GetAxisRaw("Jump") + ((UIController.jumpbuttonDown) ? 1.0f : 0.0f);

            //set animation state based on x input
            state = (x == 0) ? PlayerAnimationStates.IDLE : PlayerAnimationStates.MOVING;


            float horizontalMoveForce = x * horizontalForce;
            float jumpMoveForce = jump * verticalForce;

            AddForce(horizontalMoveForce, jumpMoveForce);
        }
        else
        {
            state = PlayerAnimationStates.JUMPING;

            float horizontalMoveForce = x * horizontalForce * airControlFactor;
            AddForce(horizontalMoveForce, 0.0f);
        }

        animator.SetInteger("State", (int)state);
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);

        isGrounded = (hit) ? true : false;
    }


    private float FlipAnimation(float x)
    {
        float size = Mathf.Abs(transform.localScale.x);
        x = (x >= 0) ? size : -size;
       transform.localScale = new Vector3(x , transform.localScale.y);

        return x;
    }


    private void AddForce(float xForce, float yForce)
    {
        float mass = rigidbody.mass * rigidbody.gravityScale;

        rigidbody.AddForce(new Vector2(xForce, yForce) * mass);

        Vector2 velocity = rigidbody.velocity;
        velocity.x *= 0.9f;
        velocity.y *= 0.99f;
        rigidbody.velocity = velocity;
    }

    public void AddJumpVelocity()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
        AddForce(0, verticalForce * 2);
    }

    //player becomes invincible for a brief moment when damaged, but it ends when this timer is completed
    void UpdateIFrameTimer()
    {
        if(invincible)
        {
            iframeTimer += Time.deltaTime;
            if(iframeTimer >= iFrameDuration)
            {
                iframeTimer = 0f;
                invincible = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform, true);
        }

        //when hit add invincibility frames
        if(!invincible && collision.gameObject.CompareTag("Hazard"))
        {
            OnHazardHit.Invoke();
            invincible = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            OnCoinCollected.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null, true);

        }
    }
}

