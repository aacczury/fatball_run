using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemEvent : MonoBehaviour {
	public float itemStartHeight = 10f;
	
	private Transform heroTransform;
	private Transform approachLeftCheck, approachRightCheck;

	private Queue itemQueue;
	private float distance;
	private string[] itemOrder = {"Enemy", "Bread", "Well"};

	private HeroState hs;
	private Text distanceTxt;

	void Awake(){
		distanceTxt = GameObject.Find ("HeroState/Distance").GetComponent<Text> ();
		hs = GameObject.Find ("Hero").GetComponent<HeroState> ();
		heroTransform = GameObject.Find ("Hero").transform;
		approachLeftCheck = heroTransform.Find("approachLeftCheck").transform;
		approachRightCheck = heroTransform.Find("approachRightCheck").transform;

		itemQueue = new Queue ();

		distance = 0;
		setItem ();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hs.currentHealth == 0 || hs.currentFood == 0 || hs.currentWater == 0)
			Destroy (GameObject.Find ("Hero"));

		if (transform.position.x + 20f > distance) {
			setItem ();
		}
		RaycastHit2D approach = Physics2D.Raycast(approachLeftCheck.position, approachRightCheck.position, approachRightCheck.position.x - approachLeftCheck.position.x, 1 << LayerMask.NameToLayer("Item") | 1 << LayerMask.NameToLayer("Non-collisive"));
		if ((Input.GetMouseButtonDown (0) || Input.GetMouseButtonUp (0)) && approach.collider) {
			Vector3 RaySource = GetComponent<Camera> ().ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(RaySource, Vector2.zero);

			if(hit.collider)
				if(hit.collider.name == approach.transform.GetChild(0).name)
					useItem(hit.collider.transform);
		}

		distanceTxt.text = ((int)transform.position.x - 9f).ToString ();
	}
	
	void setItem(){
		distance += Random.Range (15f, 40f);
		string itemName = itemOrder[Random.Range(0, 3)];
		GameObject clone = Instantiate (Resources.Load (itemName), new Vector2 (distance, itemStartHeight), Quaternion.identity) as GameObject;
		clone.transform.GetChild(0).name += "_" + distance;
	}

	void useItem(Transform itemTransform){
		string itemName = itemTransform.name;
		if(itemName.Contains("KillButton")){
			hs.currentHealth -= 10;
			hs.currentFood -= 5;
			Destroy(itemTransform.parent.gameObject);
			GameObject.Find("Hero").GetComponent<HeroContral>().pushHero();
		}
		else if(itemName.Contains("EatButton")){
			hs.currentHealth += 10;
			hs.currentFood += 5;
			hs.currentWater -= 10;
			Destroy(itemTransform.parent.gameObject);
		}
		else if(itemName.Contains("DrinkButton")){
			hs.currentFood -= 5;
			hs.currentWater += 5;
			Destroy(itemTransform.parent.gameObject);
		}
		hs.currentHealth = Mathf.Clamp(hs.currentHealth, 0, hs.maxHealth);
		hs.currentFood = Mathf.Clamp(hs.currentFood, 0, hs.maxFood);
		hs.currentWater = Mathf.Clamp(hs.currentWater, 0, hs.maxWater);
	}
}
