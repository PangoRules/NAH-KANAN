using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 5f;
	public float speed = 2f;
	public float jumpPower = 20.5f;
	private bool jump;
	public bool isJumping = false;
	private Rigidbody2D rb2d;
	private Animator anim;
	public bool grounded;
	public bool left;
	public bool right;
	float h;
	private bool moveLeft = false;
	private bool moveRight = false;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		player = GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));	
		anim.SetBool("Grounded", grounded);
		anim.SetBool("Right",right);
		anim.SetBool("Left",left);
		anim.SetBool("Jumping",isJumping);
		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
		{
			jump = true;
			isJumping = true;
		}
	}

	void FixedUpdate()
	{
		h = Input.GetAxis("Horizontal");
		if(h<0 || moveLeft){
			left = true;
			right = false;
			rb2d.AddForce(Vector2.left * speed);
		}else if(h>0 || moveRight){
			left = false;
			right = true;
			rb2d.AddForce(Vector2.right * speed);
		}

		if (rb2d.velocity.x > maxSpeed)
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed)
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}

		if (jump)
		{
			rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}
	}
	public void moveRightTouch(){
		moveRight = true;
	}
	public void moveLeftTouch(){
		moveLeft = true;
	}
	public void stopRightTouch(){
		moveRight = false;
	}
	public void stopLeftTouch(){
		moveLeft = false;
	}
	public void jumpTouch(){
		if(grounded){
			jump = true;
			isJumping = true;
		}
	}
	private void OnCollisionEnter2D(Collision2D player) {
		isJumping = false;
	}
}
