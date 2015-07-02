using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public GameOverController gameOverController;
	
	public float maxSpeed = 10f;
	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float moveH = 0;
		float moveV = 0;
		if (!gameOverController.IsGameOver ()) {
			moveH = Input.GetAxis ("Horizontal");
			moveV = Input.GetAxis ("Vertical");
			if (moveH == 0 && moveV == 0) {
				moveH = CrossPlatformInputManager.GetAxis ("Horizontal");
				moveV = CrossPlatformInputManager.GetAxis ("Vertical");
			}
		}
		rb.velocity = new Vector2 (moveH * maxSpeed, moveV * maxSpeed);
	}
}
































