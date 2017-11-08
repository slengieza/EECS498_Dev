using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;

public class VoiceCommands : MonoBehaviour {

	enum MoveDirection {Forward, Backward, Left, Right, Up, Down};
	enum RotationDirection {Left, Right, Up, Down};
	float speed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rotate (RotationDirection.Up);
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
			target = transform.position;
		}

		transform.position = Vector3.MoveTowards(transform.position, transform.position + target, step);
	}


	void Rotate(RotationDirection dir) {
		float step = speed * Time.deltaTime;
		Quaternion delta;

		if (dir == RotationDirection.Left) {
			delta = new Quaternion (-90, 0, 0, 0);
		} else if (dir == RotationDirection.Right) {
			delta = new Quaternion (90, 0, 0, 0);
		} else if (dir == RotationDirection.Up) {
			delta = new Quaternion (0, 90, 0, 0);
		} else if (dir == RotationDirection.Down) {
			delta = new Quaternion (0, -90, 0, 0);
		} else {
			delta = transform.rotation;
		}
		Transform target = transform;
		target.rotation[0] = transform.rotation [0] + delta [0];
		target.rotation[1] = transform.rotation [1] + delta [1];
		target.rotation[2] = transform.rotation [2] + delta [2];
		target.rotation[3] = transform.rotation [3] + delta [3];

		transform.rotation = Quaternion.RotateTowards (transform.rotation, target.rotation + target, step);
	}

	void Scale(bool larger) {
		float step = speed * Time.deltaTime;
		Vector3 target;

		if (larger) {
			
		} else {

		}
	}

	void UpdateSpeed(bool faster) {
		if (faster) {
			speed *= 1.5f;
		} else {
			speed *= 0.66f;
		}
	}
}
