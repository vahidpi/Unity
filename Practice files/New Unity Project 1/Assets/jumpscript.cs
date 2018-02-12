using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Jump")) {
			Rigidbody body = GetComponent<Rigidbody> ();
			if (body != null) {
				body.AddForce (new Vector3(0,300));
			}
		}
	}
}
