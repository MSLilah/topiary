﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpForceMagnitude = 700f;

	private bool canJumpGround = true;
	private bool facingRight = true;
	private bool canJumpWall = false;

	bool grounded = false;
	public Transform groundCheck;
	float groundWallRadius = 0.2f;
	public LayerMask whatIsGround;

	bool wallJumpLeft = false;
	bool wallJumpRight = false;
	public Transform wallCheckRight;
	public Transform wallCheckLeft;
	public LayerMask whatIsWall;
	
	void FixedUpdate () {
		MovePlayer ();
	}

	void MovePlayer() {
		float move = Input.GetAxis ("Horizontal");

		if (grounded)
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		else {
			float velocityChange = Mathf.Clamp(move * maxSpeed / 4 + rigidbody2D.velocity.x, -maxSpeed, maxSpeed);
			rigidbody2D.velocity = new Vector2(velocityChange, rigidbody2D.velocity.y);
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

	void Flip() {
		facingRight = !facingRight;
	}
}
