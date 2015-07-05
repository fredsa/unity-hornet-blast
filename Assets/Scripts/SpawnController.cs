using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject waypointsPrefab;
	public float speed = 1f;
	public float delay = 0f;
	public float rate = 1f;

	LayerMask layermask;
	bool needSpawn = false;
	float checkRadius;

	void Start () {
		layermask = LayerMask.GetMask("Enemies");
		InvokeRepeating ("Spawn", delay, rate);
	}
	
	void Spawn () {
		needSpawn = true;
	}

	void Update() {
		if (!needSpawn) {
			return;
		}

		if (checkRadius > 0f) {
			bool collision = Physics2D.OverlapCircleAll (transform.position, checkRadius, layermask).Length > 1;
			if (collision) {
				Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.one * checkRadius, Color.red);
				Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position - Vector2.one * checkRadius, Color.blue);
//				Debug.Log (Physics2D.OverlapCircle (transform.position, checkRadius));
				return;
			}
		}
//		Debug.Log (Physics2D.OverlapCircle (transform.position, checkRadius));
		
		needSpawn = false;
		GameObject enemyClone = Instantiate (enemyPrefab, transform.position, transform.rotation) as GameObject;
		enemyClone.transform.parent = gameObject.transform;

		GameObject waypointsClone = Instantiate (waypointsPrefab, transform.position, transform.rotation) as GameObject;
		WaypointController waypointsController = enemyClone.GetComponent<WaypointController> ();
		waypointsController.SetWaypoints (waypointsClone, speed);

		if (checkRadius == 0f) {
			CircleCollider2D collider = enemyClone.GetComponentInChildren<CircleCollider2D> () as CircleCollider2D;
			Vector2 cloneScale = ((Vector2)enemyClone.transform.localScale);
//			Debug.Log(collider.radius + " * " + cloneScale.magnitude + " (" + cloneScale + ")");
			checkRadius = collider.radius * cloneScale.magnitude / 2;
		}
	}
}
