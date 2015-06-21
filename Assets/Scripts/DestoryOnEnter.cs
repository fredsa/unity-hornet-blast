using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DestoryOnEnter : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			Destroy (other.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Bullet")) 
		{
			Destroy (other.gameObject);
		}
	}
	
}
