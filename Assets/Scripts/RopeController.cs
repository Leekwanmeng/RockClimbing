﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour {

	/*Public Fields*/
	public LineRenderer lineRenderer;
	public bool ropeActive;

	/*Private Fields*/
	private SpringJoint2D rope;
	private Vector2 touchPosition;

	void Start() {
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		TouchDetection();
	}

	// Update per physics frame
	void FixedUpdate() {
	}

	// Last update
	void LateUpdate() {
		RenderRope();
	}


	/*
	* Updates after all update functions called
	* Adds LineRenderer to existing rope (from player to anchor)
	*/
	void RenderRope() {
		if (rope != null) {
			lineRenderer.enabled = true;
			lineRenderer.positionCount = 2;
			lineRenderer.SetPosition(0, gameObject.transform.position);
			lineRenderer.SetPosition(1, rope.connectedAnchor);
		} else {
			lineRenderer.enabled = false;
		}
	}


	/*
	* Detects Touches on mobile phone
	* Creates rope on touch if no rope exists, else removes current rope
	*/
	void TouchDetection() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began ||
				touch.phase == TouchPhase.Stationary ||
				touch.phase == TouchPhase.Moved) {

				touchPosition = Camera.main.ScreenToWorldPoint
				(new Vector2(touch.position.x, touch.position.y));
				// TODO: dotted line


			} else if (touch.phase == TouchPhase.Ended) {
				if (!ropeActive) {
					touchPosition = Camera.main.ScreenToWorldPoint
					(new Vector2(touch.position.x, touch.position.y));
					ShootRope(touchPosition);
				} else {
					DestroyRope();
				}
			}
		}
	}


	/*
	* Raycasts to clicked position if it collides with a wall
	* Adds new rope if successful while deleting previous rope
	*/
	void ShootRope(Vector2 touchPosition) {
		// Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 playerPosition = gameObject.transform.position;
		Vector2 direction = touchPosition - playerPosition;

		RaycastHit2D hit = Physics2D.Raycast (playerPosition, direction, 
			Mathf.Infinity, 1 << LayerMask.NameToLayer("Wall"));

		if (hit.collider != null) {
			rope = gameObject.AddComponent<SpringJoint2D>();
			rope.enableCollision = false;
			rope.frequency = 0.2f;
			rope.connectedAnchor = hit.point;
			rope.enabled = true;
			ropeActive = true;
		}
	}


	/*
	* Destroys rope if exists
	*/
	void DestroyRope() {
		GameObject.Destroy(rope);
		ropeActive = false;
	}

}
