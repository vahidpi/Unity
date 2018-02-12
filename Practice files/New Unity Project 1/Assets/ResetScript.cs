using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour {

	public ManageLevelScript levelManager;

	void OnTriggerExit (Collider other) {
		levelManager.UpdateLives();
	}
	
}
