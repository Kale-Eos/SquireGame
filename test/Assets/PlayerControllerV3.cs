using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV3 : MonoBehaviour
{
    //Variables

    [Space]
    [Header("Movement & Jump Settings:")]
    public float movementSpeed;
    public float jumpHeight;
    private float horizontalInput;

    private int extraJumps;
    public int extraJumpsAmount;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Rigidbody2D rb;

    private bool facingRight = true;

    [Space]
    [Header("Ground Check Settings:")]
    public bool isGrounded;
    public bool isGroundedOnWall;
    public bool isOnGroundWallLayer;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    public LayerMask groundAndWallLayer;

    [Space]
    [Header("Wall Check Settings:")]
    public float wallClimbSpeed;
    private bool isNextToWall;
    private bool isNextToWall2;
    private bool isNextToWallGround;
    private bool isNextToWallGround2;
    public Transform wallCheck;
    public Transform wallCheck2;
    public float checkRadiusWall;
    public LayerMask wallLayer;



    void Start()
    {
        //Used to that it's up to the inspector to determine how many extra jumps there are.
        extraJumps = extraJumpsAmount;

        //References RigidBody2D to variable rb
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //If you want to both climb & jump on a platform, set the platform's layer to the GroundAndWall Layer
        //If you want to only jump on a platform, set the platform's layer to the GroundOnly Layer
        //If you want to only climb on a platform, set the platform's layer to the WallOnly Layer


        //Ground check. If the ground layer is touching the radius (which is an empty object placed under the player) then it's grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        isGroundedOnWall = Physics2D.OverlapCircle(groundCheck.position, checkRadius, wallLayer);

        //Ground check but it uses a combined wall and ground layer, making it easier to create platforms to climb and jump on at the same time.
        isOnGroundWallLayer = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundAndWallLayer);

        //Wall check. If the wall layer is touching the radius (which is an empty object placed next to the player) then it's next to a wall.
        //The reason why there are two wall checks is because there's a check area placed at the top and the bottom of the character.
        isNextToWall = Physics2D.OverlapCircle(wallCheck.position, checkRadiusWall, wallLayer);
        isNextToWall2 = Physics2D.OverlapCircle(wallCheck2.position, checkRadiusWall, wallLayer);

        //Wall check but it uses a combined wall and ground layer, making it easier to create platforms to climb and jump on at the same time.
        isNextToWallGround = Physics2D.OverlapCircle(wallCheck.position, checkRadiusWall, groundAndWallLayer);
        isNextToWallGround2 = Physics2D.OverlapCircle(wallCheck2.position, checkRadiusWall, groundAndWallLayer);


        //Sets horizontalInput to horizontal movement, or left and right movement
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //What actually gets the player moving.
        //Horizontal input is 1 if going right and -1 if going left. It is then multiplied by the movementSpeed variable. 
        //Since the y-axis isn't affected, y on the Vector2 is just set to rb.velocity.y
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);

        //If the player isn't facing right but is moving right, flip the sprite so it's facing right.
        //If the player isn't facing left but is moving left, flip the sprite so it's facing left.
        if (facingRight == false && horizontalInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && horizontalInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        //Resets amount of extra jumps a player has once they touch the ground.
        if (isGrounded == true || isOnGroundWallLayer == true || isGroundedOnWall == true)
        {
            extraJumps = extraJumpsAmount;
        }

        //If the player jumps and if they have extra jumps, allow them to jump at a height determined by the jumpHeight variable.
        //Decreases the amount of extra jumps each time. 
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true || Input.GetButtonDown("Jump") && extraJumps == 0 && isOnGroundWallLayer == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpHeight;
        }

        //Holding jump allows you to jump higher as long as the isJumping value is true.
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }

        //When user lets go of the jump button the isJumping bool turns false.
        if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }


            //Allows wall climb on the WallOnly Layer when the player is close to wall and presses space.
            if (Input.GetButtonDown("Jump") && isNextToWall == true || Input.GetButtonDown("Jump") && isNextToWall2 == true)
        {
            isJumping = false;
            rb.velocity = Vector2.up * wallClimbSpeed;
        }

        //Allows wall climb on the GroundAndWall Layer when the player is close to wall and presses space.
        if (Input.GetButtonDown("Jump") && isNextToWallGround == true || Input.GetButtonDown("Jump") && isNextToWallGround2 == true)
        {
            isJumping = false;
            rb.velocity = Vector2.up * wallClimbSpeed;
        }

    }

    void Flip()
    {
        //Flip function used if the player is looking left. Flips the character's sprite.
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
