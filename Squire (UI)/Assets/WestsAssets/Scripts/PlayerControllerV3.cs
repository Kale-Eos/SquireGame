﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV3 : MonoBehaviour
{
    //Variables

    [Space]
    [Header("Movement & Jump Settings:")]
    public float movementSpeed;
    public float jumpHeight;
    public float horizontalInput;

    private int extraJumps;
    public int extraJumpsAmount;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Rigidbody2D rb;

    private bool facingRight = true;

	public GameObject Greaves2;

    public Animator anim;

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
    private int maxWallJumpReset;
    public int maxWallJumps;
    public bool isNextToWall;
    public bool isNextToWall2;
    public bool isNextToWallGround;
    public bool isNextToWallGround2;
    public Transform wallCheck;
    public Transform wallCheck2;
    public float checkRadiusWall;
    public LayerMask wallLayer;

    [Space]
    [Header("Interaction Settings:")]
    public bool isNextToInteractable;
    public bool isNextToInteractable2;
    public Transform interactableCheck;
    public Transform interactableCheck2;
    public float checkRadiusInteractable;
    public LayerMask interactableLayer;


    [Space]
    [Header("Other:")]
    public GameObject TriggerDoor;    // sets TriggerDoor object
    AudioManager audioManager;      // audio manager is now accessed

    void Start()
    {
        audioManager = AudioManager.instance;               // instantiates AudioManager
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager Found");
        }

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        //Used to that it's up to the inspector to determine how many extra jumps there are.
        extraJumps = extraJumpsAmount;

        //Used to later reset maxWallJumps back to its original value.
        maxWallJumpReset = maxWallJumps;

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

        //Checks if an interactable object is next to the player, like the ground and wall checks.
        isNextToInteractable = Physics2D.OverlapCircle(interactableCheck.position, checkRadiusInteractable, interactableLayer);
        isNextToInteractable2 = Physics2D.OverlapCircle(interactableCheck2.position, checkRadiusInteractable, interactableLayer);

        //Sets horizontalInput to horizontal movement, or left and right movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(horizontalInput));



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
            anim.SetBool("jumping", false);
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
            if (jumpTimeCounter > 0)
            {
                anim.SetBool("jumping", true);
                rb.velocity = Vector2.up * jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }

        //When user lets go of the jump button the isJumping bool turns false.
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }


        //Allows wall climb on the WallOnly Layer or the GroundWall Layer when the player is close to wall and presses space. If the player is on the ground and next to the wall, it'll use the regular jump code and not the wall jump code.
        if(isGrounded == false && isGroundedOnWall == false && isOnGroundWallLayer == false)
        {
            if (Input.GetButtonDown("Jump") && isNextToWall == true && maxWallJumps > 0 || Input.GetButtonDown("Jump") && isNextToWall2 == true && maxWallJumps > 0 || Input.GetButtonDown("Jump") && isNextToWallGround == true && maxWallJumps > 0 || Input.GetButtonDown("Jump") && isNextToWallGround2 == true && maxWallJumps > 0)
            {
                isJumping = false;
                rb.velocity = Vector2.up * wallClimbSpeed;
                maxWallJumps--;
            }
        }


        //Resets the wall jump if there's no contact with a wall.
        if (isGrounded == true || isGroundedOnWall == true || isOnGroundWallLayer == true)
        {
            maxWallJumps = maxWallJumpReset;
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

    // sets the collision for Squire
    void OnTriggerEnter2D(Collider2D other)
    {
        // targests only PickUps
        if (other.gameObject.CompareTag("PickUps"))
        {
            // PickUp is destroyed and makes sound
            other.gameObject.SetActive(false);
            Greaves2.SetActive(true);
            audioManager.PlaySound("PickupSound");      // plays PickupSound.wav
        }
    }
}