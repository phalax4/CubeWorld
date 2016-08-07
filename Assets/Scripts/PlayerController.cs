using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;

	private bool grounded = false;
	public Transform groundCheck;
	public float moveSpeed;
	public float jumpHeight;
	private bool doubleJumped;


	public float health;
	public float mana;
	public float stamina;

	//private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		//anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

	}

	void Update ()
	{
		if (grounded) {
			doubleJumped = false;
		}

		//anim.SetBool ("Grounded", grounded);

		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W)) && grounded) {
			//rb2d.velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			Jump ();
		}
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W)) && !doubleJumped && !grounded) {
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			Jump ();
			doubleJumped = true;
		}
		if (Input.GetKey (KeyCode.D)) {
			rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
		}

		if (Input.GetKey (KeyCode.A)) {
			rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);
		}

		//anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x)); //tell us if moving left or right and do animation as long as not 0
		if (rb2d.velocity.x > 0 && !facingRight) { //moving right so stay same.
			Flip ();
		} else if (rb2d.velocity.x < 0 && facingRight) {
			Flip ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));


	
	}

	public void Jump ()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
	}


	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
