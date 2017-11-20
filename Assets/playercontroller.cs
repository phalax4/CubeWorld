using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {
	public float speedForce = 50f;
	public float jumpForce = 5f;

	public Vector2 jumpVector;
	public bool isGrounded;

	public Transform grounder;
	public float radius;
	public LayerMask ground;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	

		if (Input.GetKey (KeyCode.A)) {
			
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-speedForce, GetComponent<Rigidbody2D>().velocity.y);
			transform.localScale = new Vector3 (-1, 1, 1);

		} else if (Input.GetKey (KeyCode.D)) {
			
			GetComponent<Rigidbody2D>().velocity = new Vector2 (speedForce, GetComponent<Rigidbody2D>().velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);
		}
		else
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);

		isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radius, ground);


		if(Input.GetKey(KeyCode.W) && isGrounded == true) {	
			GetComponent<Rigidbody2D> ().velocity = new Vector2
				(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
		}

	}
		
}
