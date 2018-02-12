using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		float x = other.gameObject.transform.position.x;		
		float y = 3;
		float z = other.gameObject.transform.position.z;

		Vector3 newPosition=new Vector3(x,y,z);

		other.gameObject.transform.position = newPosition;

	}
}
