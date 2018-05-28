using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	public Rigidbody2D rb2d;

	public float force;
	public float minForce;
	public float maxForce;

	public float speed;


	public float maxMousePressLong;
	private float clickStart=0;
	private bool click = false;
	private bool jump = false;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {


		transform.position += transform.right * Time.deltaTime * speed;

		if (Input.GetMouseButton(0)) {
			click = true;
			clickStart = Time.time;
			Debug.Log (clickStart);
			jump = true;

		} 

		if (click && !(Time.time - clickStart < maxMousePressLong)) {
			//click = false;
		}

		if (click && (Time.time-clickStart<maxMousePressLong) ) {
			force += 5 * Time.deltaTime;
			//click = false;
		}


		if (jump) {
			if (Input.GetMouseButtonUp (0) || (Time.time - clickStart >= maxMousePressLong)) {
			
				force = Mathf.Clamp (force, minForce, maxForce);
				//Debug.Log (force);     
				//clickStart=0;
				Launch (force, Vector2.up);

				click = false;
				force = 0;
				jump = false;
			}
		}


	}

	void Launch(float forceAmount, Vector2 dir)
	{
		rb2d.AddForce(dir * forceAmount, ForceMode2D.Impulse);

	}

	void GoForward()
	{
		//rb2d.AddForce(dir * fo, ForceMode2D.Impulse);

	}
}
