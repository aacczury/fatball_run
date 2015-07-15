using UnityEngine;
using System.Collections;

public class HeroState : MonoBehaviour {

	public float maxHealth = 100f;
	public float maxFood = 100f;
	public float maxWater = 100f;
	public float currentHealth = 100f;
	public float currentFood = 100f;
	public float currentWater = 100f;
	
	private Transform health, food, water;
	private RectTransform healthTransform, foodTransform, waterTransform;
	private Vector2 healthFullPos, healthEmptyPos;
	private Vector2 foodFullPos, foodEmptyPos;
	private Vector2 waterFullPos, waterEmptyPos;


	void Awake(){
		GameObject heroState = GameObject.Find ("HeroState");
		health = heroState.transform.Find("HealthMask/Health");
		food = heroState.transform.Find("FoodMask/Food");
		water = heroState.transform.Find("WaterMask/Water");

		healthTransform = health.GetComponent<RectTransform> ();
		foodTransform = food.GetComponent<RectTransform> ();
		waterTransform = water.GetComponent<RectTransform> ();


		healthFullPos = healthTransform.position;
		healthEmptyPos = new Vector2(healthTransform.position.x - healthTransform.rect.width, healthTransform.position.y);
		foodFullPos = foodTransform.position;
		foodEmptyPos = new Vector2(foodTransform.position.x - foodTransform.rect.width, foodTransform.position.y);
		waterFullPos = healthTransform.position;
		waterEmptyPos = new Vector2(waterTransform.position.x - waterTransform.rect.width, waterTransform.position.y);
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		healthTransform.localPosition = Vector2.Lerp(healthEmptyPos, healthFullPos, currentHealth / maxHealth);
		foodTransform.localPosition = Vector2.Lerp(foodEmptyPos, foodFullPos, currentFood / maxFood);
		waterTransform.localPosition = Vector2.Lerp(waterEmptyPos, waterFullPos, currentWater / maxWater);
	}
}
