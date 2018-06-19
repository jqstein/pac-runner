using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour {

	private GameObject destructorPoint;

	// Use this for initialization
	void Start () {
		destructorPoint = GameObject.FindGameObjectWithTag ("DestructorPoint");
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < destructorPoint.transform.position.x) {
			Destroy (this.gameObject);
		}
	}
}
