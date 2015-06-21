using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

	public GameObject explosionPrefab;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

}
