using UnityEngine;
using System.Collections;

public class ItemEvent : MonoBehaviour {
	
	
	private Transform heroTransform;
	private Transform approachCheck;

	private Queue itemQueue;
	private float distance;
	private string[] itemOrder = {"Enemy", "Bread", "Well"};

	void Awake(){
		heroTransform = GameObject.Find ("Hero").transform;
		approachCheck = heroTransform.Find("approachCheck").transform;

		itemQueue = new Queue ();

		distance = 0;
		distance += Random.Range (10f, 30f);
		setItem (itemOrder[Random.Range(0, 3)], distance);

	}

	void setItem(string itemName, float x){
		GameObject clone = Instantiate (Resources.Load (itemName), new Vector2 (x, 1.248392f), Quaternion.identity) as GameObject;
		clone.transform.GetChild(0).name += "_" + distance;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x + 20f > distance) {
			distance += Random.Range (10f, 30f);
			setItem (itemOrder[Random.Range(0, 3)], distance);
		}
		RaycastHit2D approach = Physics2D.Raycast(heroTransform.position, approachCheck.position, approachCheck.position.x - heroTransform.position.x, 1 << LayerMask.NameToLayer("Item") | 1 << LayerMask.NameToLayer("Non-collisive"));
		if (Input.GetMouseButtonUp (0) && approach.collider) {
			Vector3 RaySource = GetComponent<Camera> ().ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(RaySource, Vector2.zero);
			if(hit.collider){
				if(hit.collider.name == approach.transform.GetChild(0).name)
					clickItem(hit.collider.name);
			}
		}
	}

	void clickItem(string itemName){
		Debug.Log (itemName);
		if(itemName.Contains("KillButton")){
			GameObject.Find("Hero").GetComponent<HeroState>().currentHealth -= 10;
			GameObject.Find("Hero").GetComponent<HeroState>().currentFood -= 5;
		}

	}
}
