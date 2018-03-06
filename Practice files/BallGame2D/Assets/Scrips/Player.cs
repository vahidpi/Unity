using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float force;
    public Rigidbody2D playerRB;
    
    public GUIStyle myGUIStyle;

    


	public float minForce;
	public float maxForce;

	public bool launched;
	public bool goingDown;
	public float highPoint;

	public float health;
	public float damage;

    public Image forceMeter;

	public bool won;

    public GameObject obstacleParticle;

    // Use this for initialization
    void Start()
    {
        myGUIStyle.fontSize = 16;
        myGUIStyle.normal.textColor=Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && launched == false)
        {
            // mouse button pressed down, increase force value
            // deltatime makes force to incease same speed on all CPUs
            force += 5 * Time.deltaTime;
            // Let's change the color of player to show we are increasing force
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if(Input.GetMouseButtonUp(0) && launched==false)
        {
            launched = true;
            // mousebutton has been released
            // Change color of player, check mouse position 
            // and launch player
            GetComponent<MeshRenderer>().material.color = Color.yellow;


			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0;

			Vector3 direction = (mousePos - transform.position).normalized;
			
			if (direction.y < 0) 
			{
				direction *= -1;
			}
            /*
			if (force < minForce) 
			{
				force = minForce;
			} else {
				force = maxForce;
			}
			*/
			force = Mathf.Clamp (force, minForce, maxForce);
			Debug.Log (force);     

			Launch(force, direction);
            force = 0;
        }

        if (playerRB.velocity.y < 0 && goingDown == false)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            highPoint = gameObject.transform.position.y;
            goingDown = true;
        }

        forceMeter.fillAmount = force/maxForce;
    }


	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("We collied to: " + collision.gameObject.name);
        // Tee if lause, jossa tarkastelet, että pallo osuu tagiin "Base"
        // jos näin käy, debuggaa osutun kappaleen nimi logiin. 
        if (collision.gameObject.CompareTag("Bar") && goingDown == true)
        {
            
            GetComponent<MeshRenderer>().material.color = Color.white;
            damage = Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * (highPoint - transform.position.y));

            TakeDamage(damage);
            
            goingDown = false;

            launched = false;
            // Kotitehtävä (saa yrittää)
            /*
             Korjaa, että damage ei voi olla NaN.
             Estä, että pelaaja ei voi ladata forcea ilmassa ja siten hypätä.
             Käytä tähän launched boolean muuttujaa!

            */
        }


        if (collision.gameObject.CompareTag ("Base") && goingDown == true) 
		{
            /*
			GetComponent<MeshRenderer> ().material.color = Color.white;
			damage = Mathf.Sqrt (2f * Mathf.Abs (Physics.gravity.y) * (highPoint - transform.position.y));

			TakeDamage (damage);
            */
			goingDown = false;
            launched = false;
		}

		if (collision.gameObject.CompareTag ("Win") && goingDown == true) 
		{
			
			goingDown = false;
			launched = false;


			won = true;

            //SceneManager.LoadScene("");
		}

        if (collision.gameObject.CompareTag("Obstacle")) {
           TakeDamage(collision.gameObject.GetComponent<Obstacle>().damage);

            //we are instancing the particle effect to the player's location

            GameObject effect = Instantiate(obstacleParticle, transform.position, Quaternion.identity) ;


            
        }

	}


    void Launch(float forceAmount, Vector3 dir)
    {
        playerRB.AddForce(dir * forceAmount, ForceMode2D.Impulse);
        goingDown = false;
    }

    void Die()
    {
        transform.position = new Vector3(-1f, 1.5f, 0);

        health = 100;
        force = 0;
        launched = false;
        goingDown = false;

        GameObject[] allBars = GameObject.FindGameObjectsWithTag("Bar");

        foreach(GameObject bar in allBars)
        {
            bar.layer = 9;

            bar.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255,255);
        }
    }
    void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
            Die();
    }

    private void OnGUI()
    {
		GUI.Label(new Rect(10, 10, 100, 20), "Force: " + force,myGUIStyle);
		GUI.Label(new Rect(10, 30, 100, 20), "Lunched: " + launched,myGUIStyle);
		GUI.Label(new Rect(10, 50, 100, 20), "GoingDown: " + goingDown,myGUIStyle);
		GUI.Label(new Rect(10, 70, 100, 20), "HighPoint: " + highPoint,myGUIStyle);
		GUI.Label(new Rect(10, 90, 100, 20), "Damage: " + damage,myGUIStyle);
		GUI.Label(new Rect(10, 110, 100, 20), "Health: " + health,myGUIStyle);
		if(won) GUI.Label(new Rect(10, 200, 100, 20), "You Won " ,myGUIStyle);
    }

   
}
