using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformGeneratorStartPoint;

	public PlayerController player;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platforms;

	// Use this for initialization
	void Start () {
		platformGeneratorStartPoint = platformGenerator.position;
		playerStartPoint = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart() {
		platforms = FindObjectsOfType<PlatformDestroyer> ();

		foreach (PlatformDestroyer platform in platforms) {
			Destroy(platform.gameObject);
		}

		player.transform.position = playerStartPoint;
		platformGenerator.position = platformGeneratorStartPoint;

	}
}
