using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float initialSpeed;
	public static float speed;
	public float jump;
	public bool isInGround;
	public static bool isMoving;
	public int powerUp;
	public LayerMask groundLayer;
	public static double roundPosition;
	public Transform groundChecker;
	public float groundCheckerRadius;
	public GameManager gameManager;
	private Rigidbody2D playerRigidBody;
	// private Collider2D playerCollider;
	private Animator playerAnimator;
	private float lastX;
	private double jumpTime;

	// Use this for initialization
	void Start () {
		initialSpeed = speed;
		playerRigidBody = GetComponent<Rigidbody2D> ();
		// playerCollider = GetComponent<Collider2D> ();
		playerAnimator = GetComponent<Animator> ();
		lastX = transform.position.x;
		jumpTime = 0.5;
	}
	
	// Update is called once per frame
	void Update () {
		// isInGround = Physics2D.IsTouchingLayers (playerCollider, groundLayer);
		isInGround = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);

		playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);

		if (Input.GetButton("Fire1") && jumpTime > 0) {
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
			jumpTime -= Time.deltaTime;
		} else {
			jumpTime = 0;
		}

		if (isInGround) {
			jumpTime = 0.5;
		}

		if (Input.GetButton ("Fire2")) {
			powerUp = 1;
		} else {
			powerUp = 0;
		}

		if (Input.GetButton ("Fire3")) {
			powerUp = 2;
		} else {
			powerUp = 0;
		}

		isMoving = lastX != transform.position.x;

		playerAnimator.SetBool ("isInGround", isInGround);
		playerAnimator.SetBool ("isMoving", isMoving);
		playerAnimator.SetInteger ("powerUp", powerUp);

		lastX = transform.position.x;
		roundPosition = Mathf.Round(transform.position.x);

		if (roundPosition < 500) {
			speed = 5;
		} else if (roundPosition < 1000) {
			speed = 10;
		} else if (roundPosition < 1500) {
			speed = 15;
		} else if (roundPosition < 2000) {
			speed = 20;
		} else if (roundPosition < 2500) {
			speed = 25;
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "DeadZone") {
			ScoreManager.isDead = true;
			speed = initialSpeed;
			gameManager.Restart ();
			PlatformGenerator.restart = true;
		}
	}

}
