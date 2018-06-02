using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructorPoint;

	// Use this for initialization
	void Start () {
		platformDestructorPoint = GameObject.FindGameObjectWithTag ("DestructorPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformDestructorPoint.transform.position.x) {
			Destroy (this.gameObject);
		}
	}
}
