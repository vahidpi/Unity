using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio1Script : MonoBehaviour {

	bool played = false; 
	
	// Update is called once per frame
	void Update () {
		if (played != true) {
			GetComponent<AudioSource> ().Play();
			played = true;
		}
	}
}
