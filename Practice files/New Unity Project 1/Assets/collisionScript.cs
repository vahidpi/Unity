using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		Debug.Log ("Colided at " + collision.relativeVelocity);
		Debug.Log ("Colided with " + collision.gameObject.name);
	}
}
