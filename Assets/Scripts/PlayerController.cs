using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jump;
	public bool isInGround;
	public LayerMask groundLayer;

	private Rigidbody2D playerRigidBody;
	private Collider2D playerCollider;
	private Animator playerAnimator;

	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<Collider2D> ();
		playerAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		isInGround = Physics2D.IsTouchingLayers (playerCollider, groundLayer);
		playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);

		if (isInGround && Input.GetKeyDown(KeyCode.Space)) {
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
		}

		playerAnimator.SetFloat ("speed", playerRigidBody.velocity.x);
		playerAnimator.SetBool ("isInGround", isInGround);
	}
}
