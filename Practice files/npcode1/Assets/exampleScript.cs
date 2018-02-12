using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exampleScript : MonoBehaviour {

	public int v1 = 0;

	void Awake(){
		Debug.Log ("Awake Called");
	}

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (3, 3, 3);

		Rigidbody body = GetComponent<Rigidbody> ();
		if (body != null) {
			body.useGravity = true;
		}

		Debug.Log ("Start called");
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Update called: "+ Time.deltaTime);	
	}

	void FixedUpdate(){
		Debug.Log ("FixedUpdate called: "+Time.deltaTime);	

		if (v1 == 100) {
			Destroy(gameObject);
		}

		v1 = v1 + 1;
	}

	void OnDestroy(){
		Debug.Log("On Destroy Called");
	}
}


