﻿using UnityEngine;
using System.Collections;

public class WaypointController : MonoBehaviour {

	public int enemyPointValue = 100;

	GameObject waypoints;
	float speed = 1f;
	Rigidbody2D rb;
	int targetWaypointIndex = -1;
	Vector2 targetPosition;
	Vector2 targetDirection;
	Vector3 referencePosition;

	void Start () {
		rb = GetComponentInChildren<Rigidbody2D> ();
		referencePosition = rb.position;
		nextTarget();
	}

	void nextTarget() {
		targetWaypointIndex = ++targetWaypointIndex % waypoints.transform.childCount;
		targetPosition = referencePosition + waypoints.transform.GetChild (targetWaypointIndex).localPosition;
	}

	public void SetWaypoints(GameObject waypoints, float speed) {
		this.speed = speed;
		this.waypoints = waypoints;
	}

	void Update() {
		Vector2 direction = targetPosition - rb.position;
		float distance = direction.magnitude;
		if (distance < .25f) {
			nextTarget ();
		}
		direction.Normalize ();
		targetDirection = direction * speed;

		rb.velocity = Vector3.Slerp (rb.velocity, targetDirection, distance/10f);

//		rb.position = Vector2.Lerp(rb.position, targetPosition, 3f * Time.deltaTime);
		
//		rb.position = Vector2.Lerp(rb.position, targetPosition, 3f * Time.deltaTime);

//		Vector2 velocity = (Vector2)rb.velocity;
//		Vector2.SmoothDamp (rb.position, targetPosition, ref velocity, .2f);
//		rb.velocity = velocity;
	}
}
