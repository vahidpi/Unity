using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


	public int horizontalPower = 100;
	public int verticalPower = 100;

	// Update is called once per frame
	void FixedUpdate () {
		float horizontalAxis= Input.GetAxis("Horizontal");
		float verticalAxis= Input.GetAxis("Vertical");

		int jump=0;

		if(Input.GetButtonDown("Jump")){
			jump=300;
		}

		Vector3 movement = new Vector3(horizontalAxis*horizontalPower,jump,verticalAxis*verticalPower);
		this.Move(movement);
	}

	void Move(Vector3 force) {
		Rigidbody body= GetComponent<Rigidbody>();
		if (body!=null){
			body.AddForce(force);
		}
	}
}
