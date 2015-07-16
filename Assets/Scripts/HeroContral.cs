using UnityEngine;
using System.Collections;

public class HeroContral : MonoBehaviour {
	public float moveForce = 300f;

	private Transform groundCheck;
	private bool grounded = false;
	private bool firstGround = false;
	void Awake(){
		groundCheck = transform.Find("groundCheck");
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!firstGround) {
			bool lastGrounded = grounded;
			grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

			if (lastGrounded != grounded){
				pushHero ();
				firstGround = true;
			}
		}
	}

	void FixedUpdate () {

	}

	public void pushHero(){
		GetComponent<Rigidbody2D> ().AddForce (Vector2.right * moveForce);
	}
}
