using UnityEngine;
using System.Collections;

public class HeroContral : MonoBehaviour {
	public float moveForce = 1f;

	private Transform groundCheck;
	private bool grounded = false;
	void Awake(){
		groundCheck = transform.Find("groundCheck");
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		bool lastGrounded = grounded;
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(lastGrounded != grounded)
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * moveForce);
	}

	void FixedUpdate () {

	}
}
