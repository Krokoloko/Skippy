using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    public int speed;

    private float speedH;
    private float slow;
    private float speedV;
    private float playerX;
    public float moveSpeed;
    private float moveCurrentSpeed;
    private float moveMax;
    private float jumpSpeed;
    private float jumpCurrentSpeed;
    private float jumpMax;
    private bool jumping;
    private bool facingLeft; 
	private BoxCollider _playerCollider;
    private colliderP _collider;
	private Rigidbody2D _rigidBody;
	private platform _platform;
    private Transform _transform;
    

	void Awake(){
        _collider = GetComponent<colliderP>();
		_playerCollider = GetComponent<BoxCollider>();
		_rigidBody = GetComponent<Rigidbody2D>();
		_platform = GetComponent<platform>();
        _transform = GetComponent<Transform>();
	}

    void start()
    {
        //moveSpeed = 3f;
        jumpSpeed = 9f;
        facingLeft = true;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");


        
    }

    // Update is called once per frame
    void Update () {
        playerX = transform.position.x;
        slow = speed * DoubleToFloat(_collider.slower);
        speedV = speed * DoubleToFloat(_collider.faster);
        speedH = speed * DoubleToFloat(_collider.higher);

        moveCurrentSpeed += Input.GetAxis("Horizontal")*moveSpeed;
        if(Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, 1) && !jumping)
        {
            _rigidBody.velocity = new Vector2(0, jumpSpeed);
            jumping = true;
        }

        _rigidBody.transform.Translate(new Vector3(moveCurrentSpeed, jumpCurrentSpeed, 0f) * Time.deltaTime);
        
        //transform.Translate(new Vector3(moveCurrentSpeed, 0f, 0f) * Time.deltaTime);
       //transform.position += new Vector3(moveCurrentSpeed, 0f, 0f) * Time.deltaTime;
        print(moveCurrentSpeed);
        print(jumpCurrentSpeed);


        
        if (!Input.anyKey)
        {
            if (!jumping && moveCurrentSpeed <= 0.05f || moveCurrentSpeed >= -0.05f) moveCurrentSpeed = 0;
            if (moveCurrentSpeed != 0) moveCurrentSpeed *= 0.9f;
        }
        if (jumpCurrentSpeed <= jumpSpeed / 8) jumpCurrentSpeed = 0;
        if (jumpCurrentSpeed != 0) jumpCurrentSpeed *= 0.9f;
        if (Physics.Raycast(transform.position, Vector3.down, 1)) jumping = false;
        /*
        if (Physics.Raycast(transform.position, Vector3.down, 1))
        {
            _rigidBody.AddForce(Input.GetAxis("Horizontal") * 11 * speedH * slow, 0, 0);
        }
        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, 1))
        {
            _rigidBody.AddForce (Vector3.up * 200 * speedV * slow);
            jumping = true;
        }
        if (jumping)
        {
            _rigidBody.AddForce(Input.GetAxis("Horizontal") * 10 * speedH * slow, 0, 0);
        }
        
        */

    }




    public void Reset(double item, double value) {
        item = value;
    }

    public static float DoubleToFloat(double dValue)
    {
        if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
        {
            return float.MaxValue;
        }
        if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
        {
            return float.MinValue;
        }
        return Convert.ToSingle(dValue);
    }
   
    
}
