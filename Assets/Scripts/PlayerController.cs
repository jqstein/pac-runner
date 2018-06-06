using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jump;
	public bool isInGround;
	public bool isMoving;
	public LayerMask groundLayer;
	public static double score;

	private Rigidbody2D playerRigidBody;
	private Collider2D playerCollider;
	private Animator playerAnimator;
	private float lastX;

	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<Collider2D> ();
		playerAnimator = GetComponent<Animator> ();
		lastX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		isInGround = Physics2D.IsTouchingLayers (playerCollider, groundLayer);
		playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);

		if (isInGround && Input.GetKeyDown(KeyCode.Space)) {
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
		}

		isMoving = lastX != transform.position.x;

		playerAnimator.SetBool ("isInGround", isInGround);
		playerAnimator.SetBool ("isMoving", isMoving);

		lastX = transform.position.x;
		score = Mathf.Round(transform.position.x);

		Debug.Log (score);
	}
}
