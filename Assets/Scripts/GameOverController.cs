using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	public void GameOver () {
		anim.SetTrigger ("GameOver");
	}
}
