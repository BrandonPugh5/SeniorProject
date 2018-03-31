using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Animator animator;
    [SerializeField]
    private bool isGrounded = false;
    private bool isJumping;
    public Transform rectTopLeft, rectBottomRight;
    public LayerMask groundLayer;
    private Rigidbody2D _rigidbody2D;
    public float jumpSpeed, maxSpeedVertical = 700f;
    public float maxSpeedHorizontal = 1f;
    public float movementSpeed = 30f;
    public static bool canClimb = false;
    private bool isFacingRight = true;
    public Transform groundCheckCircle;
    public float groundRadius;

    private GameObject playerRig, rightArm, rayGun;

    private void Awake()
    {
        playerRig = GameObject.Find("PlayerRig");
        rightArm = GameObject.Find("RightArm");
        rayGun = GameObject.Find("RayGun");
        groundCheckCircle = transform.Find("GroundCheck");
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = transform.Find("PlayerRig").GetComponent<Animator>();

    }
    
	//private void Update () {

 //       isGrounded = false;
 //       if(isGrounded && Input.GetButtonDown("Jump"))
 //       {

 //           animator.SetBool("isGrounded", false);
 //           animator.SetBool("isJumping", true);
 //           isJumping = true;
 //       }
 //   }

    private void FixedUpdate()
    {
        isGrounded = false;
        RaycastHit2D groundRay = Physics2D.Raycast(groundCheckCircle.position, Vector2.down, groundRadius, groundLayer);
        isGrounded = (groundRay.collider != null) ? true : false;
        Debug.DrawRay(groundCheckCircle.position, Vector2.down, Color.red);
        animator.SetBool("isGrounded", isGrounded);

        animator.SetFloat("vSpeed", _rigidbody2D.velocity.y);
        
    }

    public void MoveCharacter(float horizontal, bool isJumping)
    {
        float xVel = _rigidbody2D.velocity.x;
        float yVel = _rigidbody2D.velocity.y;
        
        if (yVel > maxSpeedVertical
            || yVel < -maxSpeedVertical)
        {
            _rigidbody2D.velocity = yVel > 0
                ? new Vector2(xVel, maxSpeedVertical)
                : new Vector2(xVel, -maxSpeedVertical);
        }
        if (xVel > maxSpeedHorizontal
            || xVel < -maxSpeedHorizontal)
        {
            _rigidbody2D.velocity = xVel > 0
                ? new Vector2(maxSpeedHorizontal, yVel)
                : new Vector2(-maxSpeedHorizontal, yVel);
        }



        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        _rigidbody2D.velocity = new Vector2(horizontal * movementSpeed, _rigidbody2D.velocity.y);

        if (isJumping && isGrounded && animator.GetBool("isGrounded"))
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isGrounded", false);
            _rigidbody2D.AddForce(new Vector2(0f, jumpSpeed));

        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    void Flip()
    {
        if (!GunInteract.isHeldByPlayer)
        {
                Transform body = playerRig.transform.Find("Body");
                Vector3 theScale = body.localScale;
                theScale.x *= -1;
                body.localScale = theScale;
            //foreach (Transform bodyParts in body)
            //{
            //    SpriteRenderer bodyPartsRenderer = bodyParts.gameObject.GetComponent<SpriteRenderer>();
            //    bodyPartsRenderer.flipX = !bodyPartsRenderer.flipX;
            //}
        }

        isFacingRight = !isFacingRight;


        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;

        

    }
}
