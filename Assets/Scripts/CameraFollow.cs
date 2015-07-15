using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float xMargin = 15f;		// Distance in the x axis the player can move before the camera follows.
	public float maxX = 1000f;		// The maximum x and y coordinates the camera can have.

	private Transform player;		// Reference to the player's transform.
	
	
	void Awake (){
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	bool CheckXMargin(){
		return Mathf.Abs(transform.position.x - player.position.x) < xMargin;
	}
	
	
	void FixedUpdate (){
		TrackPlayer();
	}
	
	
	void TrackPlayer (){
		float targetX = transform.position.x;

		targetX = player.position.x + xMargin;
		targetX = Mathf.Clamp(targetX, 0, maxX);

		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}
}
