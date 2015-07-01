using UnityEngine;
using System.Collections;

public class PlayerFireController : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D projectile;

	AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") || Input.GetKey(KeyCode.Space)) {
			Rigidbody2D clone;
			clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
			clone.velocity = transform.TransformDirection(Vector2.up * speed);

			sound.Play();
		}
	}
}
