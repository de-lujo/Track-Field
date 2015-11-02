using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jumpForce = 350f;

	bool facingRight = true;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;


    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	
		GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetBool("ground", grounded);

		/*if(grounded && Input.GetButtonDown("Jump")){

			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce));
            anim.SetBool("ground", grounded);

        }*/

        if (move>0 && !facingRight)
			Flip();
		else if(move<0 && facingRight)
			Flip();
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
