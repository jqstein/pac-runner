using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour {

	private PlayerController player;
	public int gemPower;
	public AudioSource gemBonusSound;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		gemBonusSound = GameObject.Find("GemBonusSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.name == "Player") {
			player.powerUp = gemPower;
			Destroy (this.gameObject);
			if(gemBonusSound.isPlaying) {
				gemBonusSound.Stop();
				gemBonusSound.Play();
			} else {
				gemBonusSound.Play();
			}
		}

		
	}
}
