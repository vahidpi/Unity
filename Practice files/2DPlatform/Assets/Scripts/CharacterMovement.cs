using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterMovement : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    public Rigidbody2D rb2D;
    public Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        /*
         * Write here code,
         * where do you use a and d to move th player
         * And space to jump.
         * Rigidbody2D.addforce to jump player
         * 10min
         */
        if (Input.GetAxis("Horizontal") != 0)
        {
            //animator.SetTrigger("Jump");
            animator.SetBool("Walk", true);
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0));
        } else {
            // we are standing
            animator.SetBool("Walk", false);
        }

        // flip the player when going other directyion
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
        //animator.parameters.SetValue("Walk", true);
        //Input.GetAxis("Vertical");

        /*
         create 3 small level
         create a small particle effect to the end of level
         create an Ice cube tage as "Enemy" to some place in the level
         create a "WorldMap" scene, where is Map.png and background
         Create a "MapPlayer" use MapIcon.png
         Player moves using w,a,s,d on map

        Next Tims:
        Dynamic health Bar for the Character
        Scene change from map tp levels and back
        Posiibly fix jump bug, sp player cannot jump in the air

         */
    }
}
