using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public GameObject Cube;
	// Update is called once per frame
	void FixedUpdate () {
		if(Cube!=null){
			float x=Cube.transform.position.x;
		float y=Cube.transform.position.y + 3;
		float z=Cube.transform.position.z - 3;

		Vector3 cameraPosition=new Vector3(x,y,z);

		transform.position=cameraPosition;	
		}
		
	}
}
