using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	public GameObject explosionPrefab;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			int points = other.GetComponent<WaypointController>().enemyPointValue;

			GameObject scoreHolder = GameObject.FindGameObjectWithTag("Score");
			ScoreTextController scoreTextController = scoreHolder.GetComponentInChildren<ScoreTextController> ();
			scoreTextController.AddPoints(points);

			GameObject clone = Instantiate(explosionPrefab, other.transform.position, other.transform.rotation) as GameObject;
			TextMesh mesh = clone.GetComponentInChildren<TextMesh>();
			mesh.text = "" + points;

			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

}
