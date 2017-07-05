using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PMovement2 : MonoBehaviour {

    private Rigidbody2D myrigidbody;

    private Animator myAnimator;

    private bool facingLeft;
    [SerializeField]
    private float Movespeed;

    [SerializeField]
    public float jumpPower;

    private Collider2D collide;

    private bool jump;

    private RaycastHit2D hit;

    float JumpTime, jumpDelay = .5f;

    [SerializeField]
    private GameObject camera;

    private cameraScript camScript;

    private bool jumped;
    private bool landed;

    /*[SerializeField]
    private Transform[] groundPoints;


    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask WhatIsGround;

    private bool isGrounded;*/




    [SerializeField]
      private float jumpForce;

    // Use this for initialization
    void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
        collide = GetComponent<Collider2D>();
        camScript = camera.GetComponent<cameraScript>();
        
    }
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (camScript.minY - 20f >= transform.position.y)
        {
            SceneManager.LoadScene("LoseScreen");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jump)
            {
                myAnimator.SetTrigger("Jump");
//                JumpTime = jumpDelay;
                rb.AddForce(Vector2.up * jumpPower);
                jump = true;
                jumped = true;
                landed = false;
            }
        }
        print("jump = " + jump);
        
        if (jumped && !landed)
        {
//          JumpTime -= Time.deltaTime;
            print(JumpTime);
            if (rb.velocity.y <= 0)
            {
                myAnimator.SetBool("Falling", true);
                landed = true;
                print("falling");
            }
        }
        
      /*  if(rb.velocity.y == 0 && jumped)
        {
            myAnimator.SetTrigger("Land");
            jumped = false;
            print("landed");
        }
        */

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (collision.transform.position.y > transform.position.y)
        {
            rb.AddForce(Vector2.down*2);
        }
        else if (rb.velocity == new Vector2(rb.velocity.x,0) )
        {
           jump = false;
           jumped = false;
            myAnimator.Play("Skippy_JumpLand");
            myAnimator.SetBool("Falling", false);
            print("landed");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        jump = true;
    }


    // Update is called once per frame
    void FixedUpdate() {

        

        float horizontal = Input.GetAxis("Horizontal");

        // isGrounded = IsGrounded();
        Flip(horizontal);

        HandleMovement(horizontal);

    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingLeft || horizontal < 0 && facingLeft)
        {
            facingLeft = !facingLeft;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    private void HandleMovement(float horizontal)
    {

        myrigidbody.velocity = new Vector2(horizontal* Movespeed, myrigidbody.velocity.y);

        myAnimator.SetFloat("speed",Mathf.Abs( horizontal));   

   /*if (isGrounded && jump)
        {
            
            isGrounded = false;
            myrigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
    private void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("kjk zoi");
            jump = true;
        }        
    }
    private void ResetValues()
    {
        jump = false;
    }

    private bool IsGrounded()
    {
        
        if (myrigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, WhatIsGround);
                
                for (int i = 0; i < colliders.Length; i++)
                {

                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                        
                    }
                }                
            }
        }
        return false;*/
    }
}
