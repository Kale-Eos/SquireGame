using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour {
	/*how fast the knight can move*/
	public float topSpeed = 10f;
	/*Tell the sprite which direction it is facing.*/
	bool facingRight = true;
	/*get reference to animator*/
	Animator anim;
	/* not grounded*/
	bool grounded = false;
	/* transform at knight's foot to see if he is touching the ground*/
	public Transform GroundCheck;
	/* how big the circle is going to be when we check distance to the ground */
	float groundRadius = 0.2f;
	/* force of the jump */
	public float jumpForce = 500f;
	/*What layer is considered the ground*/
	public LayerMask whatIsGround;
	void Start() {
		anim = GetComponent<Animator>();
	}
	/*pysics in fixed update*/
	void FixedUpdate(){
		/* True of false did the ground transform hit the whatIsGround with the groundRadius */
		grounded = Physics2D.OverlapCircle (GroundCheck.position, groundRadius, whatIsGround);
		/* tell the animator that we are grounded*/
		anim.SetBool("Ground", grounded);
		/* get how fast we are moving up or down from the rigidbody */
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
		/*get move direction*/
		float move = Input.GetAxis("Horizontal");
		/*add velocity to the rigidbody in the move direction * our speed*/
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs(move));
		/*if we're facing the negative direction and not facing right, flip*/
		if (move > 0 && !facingRight)
			Flip();
		else if (move < 0 && facingRight)
			Flip();
	}
	void Update() {
		if(grounded && Input.GetKeyDown(KeyCode.Space)) {
			/* not on the ground*/
			anim.SetBool("Ground", false);
			/* add jumpforce to the y axis of the rigidbody*/
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}
			}

	void Flip() {
		/*say we are facing opposite direction*/
		facingRight = !facingRight;
		/*get the local scale*/
		Vector3 theScale = transform.localScale;
		/*flip on the x axis*/
		theScale.x *= -1;
		/*applt that to the local scale*/
		transform.localScale = theScale;
	}
}
