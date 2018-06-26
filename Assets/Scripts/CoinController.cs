using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	private int coinValue = 10;

	private ScoreManager scoreManager;
	
	public AudioSource coinSound;

	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
		coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.name == "Player") {
			scoreManager.AddValue (coinValue);
			Destroy (this.gameObject);
			if(coinSound.isPlaying) {
				coinSound.Stop();
				coinSound.Play();
			} else {
				coinSound.Play();
			}
			
		}

		
	}
}
