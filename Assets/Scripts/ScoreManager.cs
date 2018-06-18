using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	private float scoreCounter;
	private float highScoreCounter;

	public static bool isDead;

	// Use this for initialization
	void Start () {
		scoreCounter = 0;
		highScoreCounter = 0;
		if (PlayerPrefs.GetFloat ("highScoreCounter") != null) {
			highScoreCounter = PlayerPrefs.GetFloat ("highScoreCounter");
			highScoreText.text = "High Score: " + highScoreCounter;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			if (scoreCounter > highScoreCounter) {
				highScoreCounter =  Mathf.Round(scoreCounter);
				PlayerPrefs.SetFloat ("highScoreCounter", highScoreCounter);
			}
			scoreCounter = 0;
			highScoreText.text = "High Score: " + highScoreCounter;
			isDead = false;
		}

		if (PlayerController.isMoving) {
			scoreCounter += Time.deltaTime;
		}

		scoreText.text = "Score: " + Mathf.Round(scoreCounter);

	}

	public void AddValue(int scoreToAdd) {
		scoreCounter += scoreToAdd;
	}
}
