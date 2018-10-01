using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Sets character speed
    public float horizontalSpeed = 5f;

    //Allows character to jump
    public float jumpVelocity = 8f;

    //Checks if grounded
    public bool isGrounded;
    public LayerMask groundLayers;

    //Sets up for the flip codes
    private bool facingRight;

    // Use this for initialization
    void Start ()
    {
        //Indicates that the player is facing right from the start.
        facingRight = true;
	}
   
    // Update is called once per frame
    void Update ()
    {
        //Code to check if grounded
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
            new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), groundLayers);

        //Code for character jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        //Code for character movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.position = transform.position + new Vector3(horizontalInput * horizontalSpeed* Time.deltaTime, 0, 0);

        //Calls the flip function
        Flip(horizontalInput);
    }
    
    //Flipping character code
    private void Flip(float horizontalInput)
    {
        //If moving right and not facing right OR if moving left and facing right
        if (horizontalInput > 0 && !facingRight || horizontalInput < 0 && facingRight)
        {
            //Then set facingRight to not facingRight
            facingRight = !facingRight;

            //Uses the player's scale
            Vector3 theScale = transform.localScale;

            //set x in theScale to -1
            theScale.x *= -1;
           
            //added theScale to the player's scale
            transform.localScale = theScale;
        }
    }
}
