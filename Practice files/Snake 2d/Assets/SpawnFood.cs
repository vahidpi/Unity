using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

	/****
		Practice Project
		https://noobtuts.com/unity/2d-snake-game
	****/


	// Food Prefab
	public GameObject foodPrefab;

	// Borders
	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;
	public bool next = true;


	// Spawn one piece of food
	void Spawn() {

		if (next) {
			// x position between left & right border
			int x = (int)Random.Range(borderLeft.position.x+1,borderRight.position.x-1);

			// y position between top & bottom border
			int y = (int)Random.Range(borderBottom.position.y+1,borderTop.position.y-1);

			// Instantiate the food at (x, y)
			Instantiate(foodPrefab,new Vector2(x, y),Quaternion.identity); // default rotation
			next=false;
		}

	}



	// Use this for initialization
	void Start () {
		// Spawn food every 4 seconds, starting in 3

		InvokeRepeating("Spawn", 0.1f, 0.1f);	
	}
}
