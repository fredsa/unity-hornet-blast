using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesTextController : MonoBehaviour {

	int lives;
	Text livesText;
	Animator animator;
	
	void Start () {
		lives = 3;
		livesText = gameObject.GetComponent<Text> ();
		animator = gameObject.GetComponent<Animator> ();
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
