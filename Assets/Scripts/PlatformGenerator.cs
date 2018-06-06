using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject[] platforms;
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
			selectedPlatform = Random.Range(0, platforms.Length);
			distanceBetweenPlatforms = Random.Range (0, 10);
			platformWidth = platforms[selectedPlatform].GetComponent<BoxCollider2D> ().size.x;
			platformHeight = Random.Range(-4, 2);

			transform.position = new Vector2(transform.position.x + distanceBetweenPlatforms + platformWidth/2 + previousPlatformWidth/2, platformHeight);
			Instantiate (platforms[selectedPlatform], transform.position, transform.rotation);

			previousPlatformWidth = platforms[selectedPlatform].GetComponent<BoxCollider2D> ().size.x;
		}
	}
}
