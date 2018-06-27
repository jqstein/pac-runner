using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgGenerator : MonoBehaviour {

	public GameObject background;
	public Transform createLocation;

	public static bool restart;

	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			transform.position = new Vector3(-30f, -2f, -1f);
			Instantiate (background, transform.position, transform.rotation);
            restart = false;
		}

		if (transform.position.x < createLocation.position.x) {
			
			transform.position = new Vector3(transform.position.x + 30, transform.position.y, transform.position.z);
			Instantiate (background, transform.position, transform.rotation);
		}
	}
}
