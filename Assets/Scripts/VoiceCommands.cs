using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;
using System;
using UnityEngine.Experimental.UIElements;

public class VoiceCommands : MonoBehaviour {

	enum MoveDirection {Forward, Backward, Left, Right, Up, Down};
	enum RotationDirection {Left, Right, Up, Down};
	enum ScaleSize {Larger, Smaller};
	float speed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		Move (MoveDirection.Right);
//		Rotate (RotationDirection.Up);
//		Scale (ScaleSize.Larger); 
	}


	void Move(MoveDirection dir){
		float step = speed * Time.deltaTime;
		Vector3 target;

		if (dir == MoveDirection.Forward) {
			target = new Vector3 (0, 0, 10);
		} else if (dir == MoveDirection.Backward) {
			target = new Vector3 (0, 0, -10);
		} else if (dir == MoveDirection.Left) {
			target = new Vector3 (-10, 0, 0);
		} else if (dir == MoveDirection.Right) {
			target = new Vector3 (10, 0 , 0);
		} else if (dir == MoveDirection.Up) {
			target = new Vector3 (0, 10, 0);
		} else if (dir == MoveDirection.Down) {
			target = new Vector3 (0, -10, 0);
		} else {
			target = new Vector3 (0, 0, 0);;
		}

		transform.position = Vector3.MoveTowards(transform.position, transform.position + target, step);
	}


	void Rotate(RotationDirection dir) {
		float step = speed * 360 * Time.deltaTime;

		if (dir == RotationDirection.Left) {
			transform.RotateAround (transform.position, Vector3.up, -step);
		} else if (dir == RotationDirection.Right) {
			transform.RotateAround (transform.position, Vector3.up, step);
		} else if (dir == RotationDirection.Up) {
			transform.RotateAround (transform.position, Vector3.right, step);
		} else if (dir == RotationDirection.Down) {
			transform.RotateAround (transform.position, Vector3.right, -step);
		}
	}

	void Scale(ScaleSize size) {
		float step = speed * Time.deltaTime;
		Vector3 target;

		if (size == ScaleSize.Larger) {
			var growthFactor = transform.localScale [0] * 1.5f;
			target = new Vector3 (growthFactor, growthFactor, growthFactor);
		} else if (size == ScaleSize.Smaller) {
			var shrinkFactor = -1 * transform.localScale [0] * 0.5f;
			target = new Vector3 (shrinkFactor, shrinkFactor, shrinkFactor);
		} else {
			target = new Vector3 (0, 0, 0);
		}


		transform.localScale = Vector3.MoveTowards (transform.localScale, transform.localScale + target, step);
	}

	void UpdateSpeed(bool faster) {
		if (faster) {
			speed *= 1.5f;
		} else {
			speed *= 0.66f;
		}
	}

	void Stop() {
		transform.localScale = Vector3.MoveTowards (transform.localScale, transform.localScale, 0);
		transform.position = Vector3.MoveTowards (transform.position, transform.position, 0);
		transform.RotateAround (transform.position, Vector3.up, 0);
		transform.RotateAround (transform.position, Vector3.right, 0);
	}
}
