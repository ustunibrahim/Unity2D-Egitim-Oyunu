using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerrb;
    Animator playerAnimator;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency=1f, nextJumpTime;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;



    public bool isGrounded = false;
    bool facingRight = true;
    void Awake()
    {
        
    }
    void Start()
    {
        playerrb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        onGroundCheck();
        Horizontalmove();
        if (playerrb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if(playerrb.velocity.x>0 && !facingRight)
        {
            FlipFace();
        }
        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jump();
        }
    }
    void FixedUpdate()
    {
        
    }
    void Horizontalmove()
    {
        playerrb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerrb.velocity.y);
        playerAnimator.SetFloat("playerspeed", Mathf.Abs(playerrb.velocity.x));
    }
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 templocalscale = transform.localScale;
        templocalscale.x *= -1;
        transform.localScale = templocalscale;
    }

    void jump()
    {
        playerrb.AddForce(new Vector2(0f,jumpSpeed));
    }
    void onGroundCheck()
    {
        isGrounded=Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
