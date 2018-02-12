using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootinscript : MonoBehaviour {
	 

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire1")) {
			Debug.Log ("Clicked fire button");


			Vector3 hitForce = new Vector3 (0, 100, 100);


			Ray ray = GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			 
			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("Hit somthing");

				if (hit.rigidbody) {
					hit.rigidbody.AddForceAtPosition (hitForce,hit.point);

				}
			}
		}
		
	}
}
