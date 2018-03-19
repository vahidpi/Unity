using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class CharacterMovement : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    public Rigidbody2D rb2D;
    public Animator animator;

    public float currentHealth;
    public float previusHealth;
    public float maxHealth;
    public float counter;
    public float maxCounter;
    public Image healthBar;


    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        previusHealth = maxHealth;


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

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Axee");
            //rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        if (counter<maxCounter)        
            counter += Time.deltaTime;        
        else
        {
            previusHealth = currentHealth;
            counter = 0;
        }
            
        

        // do animator for healthbar
        healthBar.fillAmount = Mathf.Lerp(previusHealth/maxHealth, currentHealth / maxHealth, counter / maxCounter);



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


        /*
         Fix jump, dont go to sky
         (put empty gameobject to the feet of the player to check when empty gameobject are contacting with ground.only when jumping is possible
         make player to throw an axe when pressed left Ctrl(instansiate)
         unity cartoon axe png
         make the axe to rotate in the air(transform.rotate)
         make the axe to attch to the object it hits(remove rigidbody )
         make limit to amount of axes and number to the UI

         make user to light up a firepalce by pressing f-button
         This means you need to instance the bonfire prefab
         turn on particle effect and a light(include in the prefab)
         if player is neat the fireplace lealth increasing slowly

         */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20f);
        }
    }

    void TakeDamage(float dmg)
    {
        counter = 0;
        previusHealth = healthBar.fillAmount * maxHealth;
        currentHealth -= dmg;
    }
}
