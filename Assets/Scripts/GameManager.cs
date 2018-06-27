using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformGeneratorStartPoint;
	public float initialSpeed;

	public PlayerController player;
	private Vector3 playerStartPoint;

	private GameObjectDestroyer[] objects;
	
	public DeathMenu theDeathScreen;
	public AudioSource backgroundSound;

	// Use this for initialization
	void Start () {
		platformGeneratorStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;
		initialSpeed = PlayerController.speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RestartMenu() {
		player.gameObject.SetActive(false);
		theDeathScreen.gameObject.SetActive(true);
		
	}

	public void Restart() {
		theDeathScreen.gameObject.SetActive(false);
		PlatformGenerator.restart = true;
		player.gameObject.SetActive(true);
		backgroundSound.Play();
		PlayerController.speed = initialSpeed;
        BgGenerator.restart = true;
		objects = FindObjectsOfType<GameObjectDestroyer> ();

		foreach (GameObjectDestroyer obj in objects) {
			Destroy(obj.gameObject);
		}

		player.transform.position = playerStartPoint;
		platformGenerator.position = platformGeneratorStartPoint;
		ScoreManager.isDead = false;
	}
}
