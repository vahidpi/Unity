using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float force;

	public GUIStyle myGUIStyle;

	public Rigidbody playerRB;

	public bool launched;
    public bool goingDown;
    public float highPoint;

    public float health;
    public float damage;


	// Use this for initialization
	void Start () {
		myGUIStyle.fontSize = 16;
		myGUIStyle.normal.textColor=Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			force += 5 * Time.deltaTime;
			GetComponent<MeshRenderer>().material.color = Color.red;
		}

		if(Input.GetMouseButtonUp(0))
		{
			GetComponent<MeshRenderer>().material.color = Color.yellow;


			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;


			Vector3 direction = (mousePos - transform.position).normalized;

            if(direction.y < 0)
            {
                direction *= -1;

            }

			Launch(force, direction);
            force = 10;
		}

		if(playerRB.velocity.y < 0 && goingDown == false)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;                  //We are going down
            highPoint = gameObject.transform.position.y;
            goingDown = true;

        }
	}

	private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We collided to: " + collision.gameObject.name);
                                                                                        //Tee if lause, jossa tarkastelet. että pallo osuu tagiin "base" jos näin käy, debuggaa osutun kappaleen nimi logiin.
        if(collision.gameObject.CompareTag("Base") && goingDown == true)
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
            damage = Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * (highPoint - transform.position.y));

            TakeDamage(damage);
            goingDown = false;

            //Kotitehtävä (saa yrittää)
            /* Korjaa, että damage ei voi olla NaN.
             Estä että pelaaja ei voi ladata force ilmassa ja sitten hypätä kun ollaan ilmassa. Käytä tähän launched boolean muuttujaa!
             */

        }

    }

	
	void Launch(float forceAmount, Vector3 dir)
    {
        playerRB.AddForce(dir * forceAmount, ForceMode.Impulse);
        goingDown = false;
    }

    void TakeDamage(float dmg)
    {
        health -= dmg;                                                                  //Sama kuin health = health - dmg
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Force: " + force,myGUIStyle);
        GUI.Label(new Rect(10, 30, 100, 20), "Launched: " + launched, myGUIStyle);
        GUI.Label(new Rect(10, 50, 100, 20), "GoingDown: " + goingDown, myGUIStyle);
        GUI.Label(new Rect(10, 70, 100, 20), "HighPoint: " + highPoint, myGUIStyle);
        GUI.Label(new Rect(10, 90, 100, 20), "Damage: " + damage, myGUIStyle);
        GUI.Label(new Rect(10, 110, 100, 20), "Health: " + health, myGUIStyle);

    }
}
