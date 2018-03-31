using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{

    float horizontal, vertical;
    SpriteRenderer spriteRenderer;
    Animator animator;
    private bool grounded = false;
    public Transform rectTopLeft, rectBottomRight;
    public LayerMask groundLayer;
    private Rigidbody2D _rigidbody2D;
    public int jumpSpeed, maxSpeedUpwards = 3;
    public int climbSpeed = 1;
    public float speed = 30f;
    public static bool canClimb = false;
    // Use this for initialization
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if(horizontal != 0 || vertical != 0)
        //{
        //    animator.SetBool("isMoving", true);
        //}
        //else
        //{
        //    animator.SetBool("isMoving", false);
        //}
        //if (horizontal < 0 && !spriteRenderer.flipX)
        //{
        //    spriteRenderer.flipX = true;
        //}
        //else if(horizontal > 0 && spriteRenderer.flipX)
        //{
        //    spriteRenderer.flipX = false;
        //}
        //if (Input.GetButton("Jump"))
        //{

        //    animator.SetBool("isGrounded", false);
        //    animator.SetBool("isJumping", true);
        //}

    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.y > maxSpeedUpwards)
        {
            print("yes");
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, maxSpeedUpwards);
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        grounded = Physics2D.OverlapArea(rectTopLeft.position, rectBottomRight.position, groundLayer);
        animator.SetBool("isGrounded", grounded);
        animator.SetBool("isCrouching", vertical == -1 ? true : false);

        if (horizontal != 0 && vertical == 0)
        {
            animator.SetBool("isMoving", true);
            _rigidbody2D.velocity = new Vector2(horizontal * speed * Time.deltaTime * 100, _rigidbody2D.velocity.y);
            //_rigidbody2D.AddForce(Vector2.right * horizontal * 5, ForceMode2D.Force);
        }

        else
        {
            animator.SetBool("isMoving", false);
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }

        if (horizontal < 0 && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetButton("Jump") && grounded)
        {
            _rigidbody2D.velocity += Vector2.up * jumpSpeed;
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
        if (Input.GetAxisRaw("Vertical") == 1 && canClimb)
        {
            animator.SetBool("isClimbing", true);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, climbSpeed);
        }
        else if (!grounded)
        {
            animator.SetBool("isClimbing", false);
            animator.SetBool("isFalling", true);
        }
    }
}
