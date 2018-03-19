using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    public Animator animator;

    public Rigidbody2D rb2D;


	// Use this for initialization
	void Start () {

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

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        }
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
        Possibly fix jump bug, so player cannot jump in the air


        */

    }
}
