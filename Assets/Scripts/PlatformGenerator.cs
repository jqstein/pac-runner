using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject[] grassPlatforms;
	public GameObject[] sandPlatforms;
	public GameObject[] dirtPlatforms;
	public GameObject[] stonePlatforms;
	public GameObject[] snowPlatforms;
	public GameObject platform;
	public Transform createLocation;

	private float previousPlatformWidth;
	private float platformWidth;
	private float distanceBetweenPlatforms;
	private float platformHeight;
	private int selectedPlatform;

	// Use this for initialization
	void Start () {
		previousPlatformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < createLocation.position.x) {
			selectedPlatform = Random.Range(0, grassPlatforms.Length);
			distanceBetweenPlatforms = Random.Range (0, PlayerController.speed);

			if (PlayerController.score < 500) {
				platform = grassPlatforms[selectedPlatform];
			} else if (PlayerController.score < 1000) {
				platform = sandPlatforms[selectedPlatform];
			} else if (PlayerController.score < 1500) {
				platform = dirtPlatforms[selectedPlatform];
			} else if (PlayerController.score < 2000) {
				platform = stonePlatforms[selectedPlatform];
			} else if (PlayerController.score < 2500) {
				platform = snowPlatforms[selectedPlatform];
			}
			platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
			platformHeight = Random.Range(-4, 2);

			transform.position = new Vector2(transform.position.x + distanceBetweenPlatforms + platformWidth/2 + previousPlatformWidth/2, platformHeight);
				Instantiate (platform, transform.position, transform.rotation);

			previousPlatformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
		}
	}
}
