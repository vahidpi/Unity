using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {

	public Transform player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		// If player is higher than bar
		if (player.position.y- 0.1f > transform.position.y) {
			GetComponent<MeshRenderer>().material.color = Color.cyan;

			gameObject.layer = 10;
			/*


			// random color
			int r= RAndom.Range(0,255);
			int g= RAndom.Range(0,255);
			int b= RAndom.Range(0,255);

			Player.gameObject.GetComponent<MeshRenderer>.material.color = new Color(r,g,b);
			*/

		}
	}
}
