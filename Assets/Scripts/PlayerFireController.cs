using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerFireController : MonoBehaviour {

	public GameOverController gameOverController;

	public float speed = 20f;
	public Rigidbody2D projectile;
	
	AudioSource sound;

	void Start () {
		sound = GetComponent<AudioSource> ();
	}

	bool IsFiring() {
		// CTRL key
		if (Input.GetButtonDown ("Fire1")) {
			return true;
		}

		// SPACE key
		if (Input.GetKeyDown (KeyCode.Space)) {
			return true;
		}
		
//		// tap on "Jump" area
		if (CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			return true;
		}

//		for (int i=0; i < Input.touches.Length; i++) {
//			if (Input.GetTouch(i).phase == TouchPhase.Began) {
//				return true;
//			}
//		}

		return false;
	}

	void Update () {
		if (IsFiring()) {
			if (gameOverController.IsGameOver()) {
//				gameOverController.SetGameOver(false);
			} else {
				Rigidbody2D clone;
				clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
				clone.velocity = transform.TransformDirection(Vector2.up * speed);

				sound.Play();
			}
		}
	}


}
