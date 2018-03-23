using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    public Animator animator;

    public Rigidbody2D rb2D;

    public float currentHealth;
    public float previousHealth;
    public float maxHealth;
    public float counter;
    public float maxCounter;
    public Image healthBar;

    public bool grounded;

    public GameObject axe;
    public float throwForce; 
    public int axeAmount;

    public GameObject bonfire; 



	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
        previousHealth = maxHealth;

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        /*
		Write here some code where you use a and d to move the player.
        And Space to jump. Use Rigidbody2D.addforce to jump player. 
        10min
        */
        if(Input.GetAxis("Horizontal") != 0)
        {
            // We are moving
            animator.SetBool("Walk", true);
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") *
                movementSpeed * Time.deltaTime, 0));
        }
        else
        {
            // We are standing still
            animator.SetBool("Walk", false);
        }

        // Flip the player when going other direction
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            // We jump here
            animator.SetTrigger("Jump");
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        }

        if (Input.GetButtonDown("Fire1") && axeAmount > 0)
        {
            Debug.Log("Let's throw an axe");
            axeAmount--;

            // two ways to do the instantiate
            GameObject axeInstance = Instantiate(axe, gameObject.transform.position, Quaternion.identity);

            axeInstance.GetComponent<Rigidbody2D>().AddForce
                (new Vector2(gameObject.transform.localScale.x * throwForce, 
                throwForce), ForceMode2D.Impulse);

            axeInstance.GetComponent<Rigidbody2D>().AddTorque(-900 * gameObject.transform.localScale.x);

            // other way to instantiate without giving any new "commands"
            //Instantiate(axe, gameObject.transform.position, Quaternion.identity);

        }

        if (Input.GetKeyDown(KeyCode.F))
        {

            Vector2 bonfirePosition = new Vector2(GameObject.Find("Foot_L").
                transform.position.x + 10 * gameObject.transform.localScale.x, 
                GameObject.Find("Foot_L").transform.position.y);

            Instantiate(bonfire, bonfirePosition, Quaternion.identity);



        }



        if (counter < maxCounter)
        {
            counter += Time.deltaTime;
        }
        else
        {
            previousHealth = currentHealth;
            counter = 0;
        }
        // This row will do animation for the HealthBar
        healthBar.fillAmount = Mathf.Lerp(previousHealth/maxHealth, 
            currentHealth / maxHealth, counter / maxCounter);


        /*
        Homework/Schoolwork
        Create 3 different small!! levels (scenes)
        Create a small particle effect to the end of each the level
        Create an IceCube (tagged as "Enemy") to some place in the level
        Create a "WorldMap" Scene, where is Map.png and background
        Create a "MapPlayer" use MapIcon.png. 
        Player moves using w,a,s,d on map

        Next time we'll do following:
        Dynamic Health Bar for the character
        Scene change from map to levels and back to map


        Homework!
        Fix jump bug, so player cannot jump in the air
        (put empty gameobject to the feet of the player and check when
        empty gameobject is contacting with the ground. Only then jumping
        is possible)

        Make player to throw an axe when pressed left-ctrl (instansiate)
        Make the axe to rotate in the air (transform.rotate)
        Make the axe to attach to the object it hits (remove rigidbody component)
        Make limit to amount of axes and number to the UI

        Make user to light up a bonfire by pressing f-button
        This means you need to instance the bonfire prefab
        Turn on particle affect and a light (included in the prefab)
        If player is near the fireplace health is increasing slowly
        

        */

    } // Update end here

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("AxeWalkable"))
        {
            grounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("AxeWalkable"))
        {
            // We know we are touching ground
            grounded = true; 
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20f);

        }
    }

    void TakeDamage(float dmg)
    {
        counter = 0;
        previousHealth = healthBar.fillAmount * maxHealth;
        currentHealth -= dmg;

    }


}
