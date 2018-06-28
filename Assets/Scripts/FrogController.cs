using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour {
	private GameObject player;
	public bool jump;
	private bool down;
	private bool playerIsInRadius;
	private float groundPosition;
	private float currentPosition;
	private float finalPosition;
	private float jumpValue;
	private Animator frogAnimator;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		jump = false;
		down = false;
		playerIsInRadius = false;
		groundPosition = transform.position.y;
		finalPosition = groundPosition + 3f;
		frogAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x - player.transform.position.x <= 5 && transform.position.x - player.transform.position.x > 0) {
			playerIsInRadius = true;
			if (player.transform.position.y - transform.position.y <= 0.5f) {
				//Debug.Log ("chão");
			} else {
				//Debug.Log ("ar");
				jump = true;
			}
		} else {
			//Debug.Log ("fora");
			//jumpCount = 0;
			playerIsInRadius = false;
		}

		if (jump) {
			currentPosition = transform.position.y;
			if (!down && currentPosition < finalPosition) {
				jumpValue = 0.1f;
			} else {
				down = true;
				jumpValue = -0.1f;
			}

			if (down && currentPosition <= groundPosition) {
				transform.position = new Vector2 (transform.position.x, groundPosition);
				jump = false;
				down = false;
			} else {
				transform.position = new Vector2 (transform.position.x, transform.position.y + jumpValue);
			}
		}

		frogAnimator.SetBool ("isJumping", jump);
	}
}
