using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject player;

	private Vector3 lastPlayerPosition;
	private float moveDistance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		lastPlayerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		moveDistance = player.transform.position.x - lastPlayerPosition.x;

		transform.position = new Vector3 (transform.position.x + moveDistance, transform.position.y, transform.position.z);

		lastPlayerPosition = player.transform.position;
	}
}
