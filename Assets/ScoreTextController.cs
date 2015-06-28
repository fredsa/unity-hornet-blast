using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextController : MonoBehaviour {

	int score;
	Text scoreText;

	void Start () {
		score = 0;
	    scoreText = gameObject.GetComponent<Text> ();
		UpdateScore ();
	}

	public void AddPoints(int points) {
		score += points;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + string.Format ("{0,4:n0}", score);
	}

	void Update () {
	}
}
