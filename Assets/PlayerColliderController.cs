using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerColliderController : MonoBehaviour {

	public GameObject explosionPrefab;
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			GameObject clone = Instantiate(explosionPrefab, other.transform.position, other.transform.rotation) as GameObject;
			TextMesh mesh = clone.GetComponentInChildren<TextMesh>();
			mesh.text = "";

			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
	
}