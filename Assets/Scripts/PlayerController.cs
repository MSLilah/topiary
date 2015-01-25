using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpForceMagnitude = 100f;
	public bool facingRight = false;

	bool grounded = false;
	public Transform groundCheck;
	float groundWallRadius = 0.2f;
	public LayerMask whatIsGround;

	bool wallJumpLeft = false;
	bool wallJumpRight = false;
	public Transform wallCheckRight;
	public Transform wallCheckLeft;
	public LayerMask whatIsWall;

	private Animator animator;
	
	/////////////////////
	/// Unity Functions
	/////////////////////

	void Start() {
		animator = GetComponent<Animator> ();
		Flip ();
	}
	
	void FixedUpdate () {
		MovePlayer ();
	}

	void Update() {
		if (Input.GetAxisRaw ("Jump") != 0) {
			if (grounded) {
				rigidbody2D.AddForce (new Vector2(0, jumpForceMagnitude));
			}
			else if (wallJumpLeft) {
				rigidbody2D.AddForce (new Vector2(jumpForceMagnitude / 2, jumpForceMagnitude));
			}
			else if (wallJumpRight) {
				rigidbody2D.AddForce (new Vector2(-jumpForceMagnitude / 2, jumpForceMagnitude));
			}
		}
	}

	/////////////////////
	/// Our Functions
	/////////////////////
	private void MovePlayer() {
		float move = Input.GetAxis ("Horizontal");

		if (grounded)
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		else {
			float velocityChange = Mathf.Clamp(move * maxSpeed / 4 + rigidbody2D.velocity.x, -maxSpeed, maxSpeed);
			rigidbody2D.velocity = new Vector2(velocityChange, rigidbody2D.velocity.y);
		}

		if (move != 0) {
			animator.SetBool("Move", true);
		}
		else {
			animator.SetBool ("Move", false);
		}

		if ((move > 0 && !facingRight) ||
		    (move < 0 && facingRight)) {
			Flip ();
		}

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundWallRadius, whatIsGround);

		wallJumpLeft = false;
		wallJumpRight = false;
		if (!grounded) {
			wallJumpLeft = Physics2D.OverlapCircle (wallCheckLeft.position, groundWallRadius, whatIsWall);
			wallJumpRight = Physics2D.OverlapCircle (wallCheckRight.position, groundWallRadius, whatIsWall);
		}
	}

	private void Flip() {
		facingRight = !facingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	
	public void WorldStateChange(bool lightWorld) {
		if (lightWorld) {
			GetComponent<GunController>().enabled = false;
			GetComponent<MeleeAttackController>().enabled = true;
		}
		else {
			GetComponent<GunController>().enabled = true;
			GetComponent<MeleeAttackController>().enabled = false;
		}
	}

}
