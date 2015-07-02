using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public GameObject player;
	public LivesController livesController;
	public ScoreTextController scoreTextController;
	public float restartDelay = 2f;

	Collider2D playerCollider;

	Animator anim;
	bool isGameOver = false;
	float restartTime = 0;

	void Start () {
		anim = GetComponent<Animator> ();
		playerCollider = player.GetComponent<Collider2D> ();
	}

	public bool IsGameOver() {
		return isGameOver;
	}

	void ResetPlayer() {
		player.transform.localPosition = new Vector3 (0, 0, 0);
	}

	public void SetGameOver (bool newGameOverState) {
		if (Time.time < restartTime) {
			return;
		}
		isGameOver = newGameOverState;
		playerCollider.enabled = !isGameOver;
		anim.SetBool ("IsGameOver", isGameOver);
		if (isGameOver) {
			restartTime = Time.time + restartDelay;
			Invoke ("ResetPlayer", restartDelay);
		} else {
			scoreTextController.ResetScore ();
			livesController.ResetLives();
		}
	}

}
