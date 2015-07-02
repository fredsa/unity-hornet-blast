using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesController : MonoBehaviour {

	int lives;
    Text livesText;
	Animator animator;
	
	void Start () {
		livesText = gameObject.GetComponent<Text> ();
		animator = gameObject.GetComponent<Animator> ();
		ResetLives ();
	}

	public int LivesRemaining() {
		return lives;
	}

	public void ResetLives() {
		lives = 3;
		UpdateScore ();
	}

	public void Die() {
		lives--;
		animator.SetTrigger ("ValueChanged");
		UpdateScore ();
	}
	
	void UpdateScore () {
		livesText.text = string.Format ("{0,-3:n0}", lives);
	}

}
