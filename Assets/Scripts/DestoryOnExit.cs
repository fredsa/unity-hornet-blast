using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DestoryOnExit : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Bullet") || other.gameObject.CompareTag ("Enemy")) 
		{
			Destroy (other.gameObject);
		}
	}
	
}
