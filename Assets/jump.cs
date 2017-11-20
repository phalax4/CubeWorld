using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {

	public float fallMultiplier = 2.5f;
	public float lowJumpMulitplier = 2f;

	Rigidbody2D rb;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (rb.velocity.y < 0) {
			
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		} else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.W)) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMulitplier - 1) * Time.deltaTime;
		}
	}
}
