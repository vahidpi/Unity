using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevelScript : MonoBehaviour {

	public int lives = 5;
	public GameObject player;

	public void UpdateLives(){
		lives=lives-1;
		Debug.Log("Current number of lives : "+ lives);


		if (player != null){
			if(lives>0){
				Rigidbody body = player.GetComponent<Rigidbody>();
				if(body !=null){
					body.velocity = Vector3.zero;
					body.angularVelocity = Vector3.zero;
				}

				Vector3 newPosition= new Vector3(0,3,0);
				player.transform.position=newPosition;				
			} else {
				Destroy(player);
			}
		}


		//player.UpdateLives();

			
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
