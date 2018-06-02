using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform location;

	private float platformWidth;
	private float distanceBetweenPlatforms;
	private float distanceBetweenPlatformsMin = 1;
	private float distanceBetweenPlatformsMax = 5;


	// Use this for initialization
	void Start () {
		platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < location.position.x) {
			distanceBetweenPlatforms = Random.Range (distanceBetweenPlatformsMin, distanceBetweenPlatformsMax);
			transform.position = new Vector2(transform.position.x + distanceBetweenPlatforms + platformWidth, transform.position.y);

			Instantiate (platform, transform.position, transform.rotation);
		}
	}
}
