using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public GameObject prefab;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("t")) {
			float x = transform.position.x+Random.Range(-3,3);
			float y = transform.position.y;
			float z = transform.position.z+Random.Range(-3,3);
			Vector3 position = new Vector3 (x, y, z);

			Instantiate (prefab,position,Quaternion.identity);
		}
	}
}
