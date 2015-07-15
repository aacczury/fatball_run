using UnityEngine;
using System.Collections;

public class ClickEvent : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Vector3 RaySource = GetComponent<Camera> ().ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(RaySource, Vector2.zero);
			if(hit.collider){
				//Debug.Log (hit.collider.name);
				if(hit.collider.name == "KillButton"){
					GameObject.Find("Hero").GetComponent<HeroState>().currentHealth -= 10;
					GameObject.Find("Hero").GetComponent<HeroState>().currentFood -= 5;
				}
			}
		}

	}
}
