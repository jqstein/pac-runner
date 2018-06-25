using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtrasGenerator : MonoBehaviour {

	private GameObject destructorPoint;
	public GameObject[] coins;
	public GameObject[] gems;
	public GameObject spike;
	private PlayerController player;
	private int randomExtra;
	private int spikesCount;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
		destructorPoint = GameObject.FindGameObjectWithTag ("DestructorPoint");
	}

	void Update () {
		if (transform.position.x < destructorPoint.transform.position.x) {
			Destroy (this.gameObject);
		}
	}

	public void SpawnExtras(Vector3 startPosition, float platformSize) {
		spikesCount = 0;
		for (int x = 1; x < platformSize; x++) {
			randomExtra = Random.Range(0, 100);
			if (randomExtra < 50) {
				GameObject coin = coins [0];
				coin.transform.position = new Vector3 (startPosition.x + x, startPosition.y, startPosition.z);
				Instantiate (coin, coin.transform.position, Quaternion.identity);
			} else if (randomExtra >= 50 && randomExtra < 53 && spikesCount < 2) {
				spikesCount++;
				spike.transform.position = new Vector3 (startPosition.x + x, startPosition.y, startPosition.z);
				Instantiate (spike, spike.transform.position, Quaternion.identity);
			} else if (randomExtra == 60 && player.powerUp == 0 && GameObject.FindGameObjectsWithTag ("Gem").Length == 0) {
				GameObject gem = gems [Random.Range (0, 3)];
				gem.transform.position = new Vector3 (startPosition.x + x, startPosition.y, startPosition.z);
				Instantiate (gem, gem.transform.position, Quaternion.identity);
				
			}
		}
	}

}
