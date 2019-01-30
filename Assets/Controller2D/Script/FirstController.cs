using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour {

    //SerializedField
    [SerializeField]
    float Speed = 1.0f;
    [SerializeField]
    float jumpForce = 250f;
    
    

    //private
    Rigidbody2D rigidBody;
    
    bool IsDoubleJump = true;
    bool IsGrounded = false;

    //public
    public bool bFacingRight = true;
    public Transform GroundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundmask;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody.bodyType == RigidbodyType2D.Kinematic)
        {
            //bkinematic = true;
        }
		
	}

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, groundmask);
        if (IsGrounded)
            IsDoubleJump = false;
        //Jump
        /*

        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }*/
        if ((IsGrounded || !IsDoubleJump) && Input.GetKeyDown(KeyCode.Space)){
            rigidBody.AddForce(new Vector2(0, jumpForce));
            if (!IsGrounded || !IsDoubleJump)
                IsDoubleJump = true;
        }

    }

    private void FixedUpdate()
    {
        //Get movement input
        float moveX = Input.GetAxis("Horizontal");

        //Assign input in Rigidbody
        rigidBody.velocity = new Vector2(moveX * Speed, rigidBody.velocity.y);

        //SpriteFlip Condition
        if ((moveX > 0 && !bFacingRight) || (moveX < 0 && bFacingRight))
        {
            FlipSprite();
        }
  
    }

    void FlipSprite()
    {
        bFacingRight = !bFacingRight;
        Vector3 spriteLocalScale = transform.localScale;
        spriteLocalScale.x *= -1;
        transform.localScale = spriteLocalScale;
    }
}
