using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public GameObject player;
	public LivesController livesController;
	public ScoreTextController scoreTextController;
	public float restartDelay = 2f;
	public Animator startButtonAnimator;
	public Button startButton;

	Collider2D playerCollider;

	Animator anim1;
	bool isGameOver = true;
	float restartTime = 0;

	void Start () {
		anim1 = GetComponent<Animator> ();
		playerCollider = player.GetComponent<Collider2D> ();
	}

	public bool IsGameOver() {
		return isGameOver;
	}

	void ResetPlayer() {
		player.transform.localPosition = new Vector3 (0, 0, 0);
		startButton.gameObject.SetActive(true);
	}

	public void SetGameOver (bool newGameOverState) {
		if (Time.time < restartTime) {
			return;
		}
		isGameOver = newGameOverState;
		playerCollider.enabled = !isGameOver;
		anim1.SetBool ("IsGameOver", isGameOver);
		startButtonAnimator.SetBool ("IsGameOver", isGameOver);
		if (isGameOver) {
			restartTime = Time.time + restartDelay;
			Invoke ("ResetPlayer", restartDelay);
		} else {
			scoreTextController.ResetScore ();
			livesController.ResetLives();
			startButton.gameObject.SetActive(false);
		}
	}

}
