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
	private float firstPlatformWidth;
	private float platformWidth;
	private float distanceBetweenPlatforms;
	private float platformHeight;
	private int selectedPlatform;
	public static bool restart;

	private ExtrasGenerator extrasGenerator;

	// Use this for initialization
	void Start () {
		firstPlatformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
		previousPlatformWidth = firstPlatformWidth;
		extrasGenerator = FindObjectOfType<ExtrasGenerator> ();
			
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			transform.position = new Vector3(4f, -4f, 0);
			Instantiate (grassPlatforms[4], transform.position, transform.rotation);
			previousPlatformWidth = firstPlatformWidth;
			restart = false;
		}
		if (transform.position.x < createLocation.position.x) {
			selectedPlatform = Random.Range(0, grassPlatforms.Length);
			distanceBetweenPlatforms = Random.Range (0, PlayerController.speed);

			if (PlayerController.roundPosition < 500) {
				platform = grassPlatforms[selectedPlatform];
			} else if (PlayerController.roundPosition < 1000) {
				platform = sandPlatforms[selectedPlatform];
			} else if (PlayerController.roundPosition < 1500) {
				platform = dirtPlatforms[selectedPlatform];
			} else if (PlayerController.roundPosition < 2000) {
				platform = stonePlatforms[selectedPlatform];
			} else if (PlayerController.roundPosition < 2500) {
				platform = snowPlatforms[selectedPlatform];
			}
			platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
			platformHeight = Random.Range(-4, 2);

			extrasGenerator.SpawnExtras (new Vector3(transform.position.x - previousPlatformWidth/2, transform.position.y + 1f, transform.position.z), previousPlatformWidth);

			transform.position = new Vector2(transform.position.x + distanceBetweenPlatforms + platformWidth/2 + previousPlatformWidth/2, platformHeight);
			Instantiate (platform, transform.position, transform.rotation);

			previousPlatformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
		}
	}
}
