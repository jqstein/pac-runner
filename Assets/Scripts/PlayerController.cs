using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float initialSpeed;
	public static float speed;
	public float jump;
	public float jumpExtra;
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
	private bool doubleJump;
	private double powerUpTime;
	private bool hpSet;

	private int hp;
	
	public AudioSource jumpSound;
	public AudioSource deathSound;
	public AudioSource backgroundSound;
	public AudioSource spikeSound;

	// Use this for initialization
	void Start () {
		hp = 1;
		initialSpeed = speed;
		playerRigidBody = GetComponent<Rigidbody2D> ();
		// playerCollider = GetComponent<Collider2D> ();
		playerAnimator = GetComponent<Animator> ();
		lastX = transform.position.x;
		jumpTime = 0.5;
		powerUpTime = 5;
		doubleJump = true;
	}
	
	// Update is called once per frame
	void Update () {
		// isInGround = Physics2D.IsTouchingLayers (playerCollider, groundLayer);
		if (hp <= 0) {
			GameOver ();
		}

		isInGround = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);

		playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);

		if (Input.GetButton("Fire1") && jumpTime > 0) {
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
			if (jumpTime == 0.5) jumpSound.Play();
			jumpTime -= Time.deltaTime;
		} else {
			jumpTime = 0;
		}

		if (isInGround) {
			jumpTime = 0.5;
			doubleJump = true;
		} else if (Input.GetButtonDown("Fire1") && doubleJump) {
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpExtra);
			doubleJump = false;
			jumpSound.Play();
		}

		if (powerUp != 0) {
			powerUpTime -= Time.deltaTime;
		} 

		if (powerUp == 1 && !hpSet) {
			hp = 9999;
			hpSet = true;
		} else if (powerUp == 2) {
			ScoreManager.multiplier = 2;
		} else if (powerUp == 3 && !hpSet) {
			hp = 2;
			hpSet = true;
		}

		if(powerUpTime <= 0) {
			powerUp = 0;
			hp = 1;
			hpSet = false;
			ScoreManager.multiplier = 1;
			powerUpTime = 5;
		}

		isMoving = lastX != transform.position.x;

		playerAnimator.SetBool ("isInGround", isInGround);
		playerAnimator.SetBool ("isMoving", isMoving);
		playerAnimator.SetInteger ("powerUp", powerUp);

		lastX = transform.position.x;
		roundPosition = Mathf.Round(transform.position.x);

		if (roundPosition < 250) {
			speed = 5;
		} else if (roundPosition < 500) {
			speed = 7;
		} else if (roundPosition < 750) {
			speed = 10;
		} else if (roundPosition < 1000) {
			speed = 12;
		} else if (roundPosition < 1500) {
			speed = 15;
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "DeadZone") {
			GameOver ();
		}

		if (collision.gameObject.tag == "Spike") {
			hp--;
            spikeSound.Play();
		}
	}

	private void GameOver() {
		deathSound.Play();
		backgroundSound.Stop();
		ScoreManager.isDead = true;
		ScoreManager.multiplier = 1;
		//PlatformGenerator.restart = false;

		speed = 0;
		powerUp = 0;
		hp = 1;
		gameManager.RestartMenu ();
	}

}
