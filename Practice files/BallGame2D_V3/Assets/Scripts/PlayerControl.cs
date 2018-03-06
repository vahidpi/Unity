using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float force;
    public Rigidbody2D playerRB;
    

	public float minForce;
	public float maxForce;

	public bool launched;
	public bool goingDown;
	public float highPoint;

	public float health;
	public float damage;

    // * public Image forceMeter;

    public GUIStyle myGUIStyle;

	// * public bool won;

    // * public GameObject obstacleParticle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0) && launched == false)
        {
            force += 5 * Time.deltaTime;        
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if(Input.GetMouseButtonUp(0) && launched==false)
        {
            launched = true;           
            GetComponent<MeshRenderer>().material.color = Color.yellow;
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0;

			Vector3 direction = (mousePos - transform.position).normalized;
			
			if (direction.y < 0) 
			{
				direction *= -1;
			}

			force = Mathf.Clamp (force, minForce, maxForce);	  

			Launch(force, direction);
            force = 0;
		}

		if (playerRB.velocity.y < 0 && goingDown == false)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            highPoint = gameObject.transform.position.y;
            goingDown = true;
        }

        // * forceMeter.fillAmount = force/maxForce;
		
	}

	void Launch(float forceAmount, Vector3 dir)
    {
        playerRB.AddForce(dir * forceAmount, ForceMode2D.Impulse);
        goingDown = false;
    }
}
