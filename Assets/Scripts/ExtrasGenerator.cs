using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasGenerator : MonoBehaviour {

	private GameObject destructorPoint;
	public GameObject[] coins;
	private int randomExtra;

	void Start () {
		destructorPoint = GameObject.FindGameObjectWithTag ("DestructorPoint");
	}

	void Update () {
		if (transform.position.x < destructorPoint.transform.position.x) {
			Destroy (this.gameObject);
		}
	}

	public void SpawnExtras(Vector3 startPosition, float platformSize) {
		for (int x = 1; x < platformSize; x++) {
			randomExtra = Random.Range(0, 20);
			if (randomExtra <= 5) {
				GameObject coin = coins [0];
				coin.transform.position = new Vector3 (startPosition.x + x, startPosition.y, startPosition.z);
				Instantiate (coin, coin.transform.position, Quaternion.identity);
			} else if (randomExtra <= 8) {
				// hazards
			} else if (randomExtra == 19 && PlayerController.powerUp == 0) {
				//power up
			}
		}
	}

}
