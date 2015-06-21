using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject prefab;
	public float delay = 0f;
	public float rate = 1f;

	bool needSpawn = false;

	void Start () {
		InvokeRepeating ("Spawn", delay, rate);
	}
	
	void Spawn () {
		needSpawn = true;
	}

	void Update() {
		if (needSpawn) {
			needSpawn = false;
			GameObject clone = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
			clone.transform.parent = gameObject.transform;
		}
	}
}
