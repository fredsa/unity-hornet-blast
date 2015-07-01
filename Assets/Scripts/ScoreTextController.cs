using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextController : MonoBehaviour {

	int score;
	Text scoreText;
	Animator animator;

	void Start () {
		score = 0;
	    scoreText = gameObject.GetComponent<Text> ();
	    animator = gameObject.GetComponent<Animator> ();
		UpdateScore ();
	}

	public void AddPoints(int points) {
		score += points;
		animator.SetTrigger ("ValueChanged");
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = string.Format ("{0,-4:n0}", score);
	}

}
