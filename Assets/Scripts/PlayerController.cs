using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Rigidbody2D myRB;
    private Animator myAnim;

    public float moveSpeed;
    public float jumpForce;
    private float regularJump;
    private float boostJump;

    public Transform playerFeet;

    public bool canJump;
    public bool jumpPowerup;

    public LayerMask ground;

    public GameObject ammo;
    public Transform ammoSpawner;
    

    // Start is called before the first frame update
    void Start()
    {
        //Grab the Rigidbody2D component on my Player game object
        myRB = GetComponent<Rigidbody2D>();

        //Grab the Animator component
        myAnim = GetComponent<Animator>();

        transform.position = new Vector3(0, 0, 0);

        regularJump = 7;
        boostJump = 10;
        jumpForce = regularJump;

    }

    // Update is called once per frame
    void Update()
    {
        
        //Create a variable to assign our Input to movement
        float moveX = Input.GetAxisRaw("Horizontal");        
         

        //take our moveX and use it to apply force to our RB
        myRB.velocity = new Vector2(moveX * moveSpeed, myRB.velocity.y);

        if (Mathf.Abs(myRB.velocity.x) > 0.1f)
        {
            myAnim.SetBool("playerMove", true);
        }
        else
        {
            myAnim.SetBool("playerMove", false);
        }

        if (moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


        canJump = Physics2D.OverlapCircle(playerFeet.transform.position, 0.25f, ground);

        // When I hit the jump button...jump
        if (Input.GetButtonDown("Jump") && canJump)
        {
            myRB.AddForce(new Vector2(0, jumpForce ),ForceMode2D.Impulse);            
        }
        
        if (Mathf.Abs(myRB.velocity.y) > 0.1f)
        {
            myAnim.SetBool("playerJump", true);
        }
        else
        {
            myAnim.SetBool("playerJump", false);
        }

        jumpBoostStart();

        shooting();
        
    }

   void jumpBoostStart()
    {
        if (jumpPowerup)
        {
            StartCoroutine(boostJumpCooldown());
        }
    }     

    void shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ammo, ammoSpawner.transform.position, Quaternion.identity);
        }
    }
    

    IEnumerator boostJumpCooldown()
    {
        jumpForce = boostJump;
        jumpPowerup = false;
        yield return new WaitForSeconds(5);        
        jumpForce = regularJump;
    }

}
