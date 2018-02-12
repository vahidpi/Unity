using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	public float speed = 1;
	// Update is called once per frame
	void Update () {
		Animator animator = GetComponent<Animator> ();

		float movement = Input.GetAxis ("Horizontal");

		animator.SetFloat ("Speed", Mathf.Abs(movement));

		Vector3 moving = new Vector3 (movement, 0);
		transform.Translate (moving * speed);
		
	}
}
