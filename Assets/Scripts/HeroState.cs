using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroState : MonoBehaviour {

	public float maxHealth = 100f;
	public float maxFood = 100f;
	public float maxWater = 100f;
	public float currentHealth = 100f;
	public float currentFood = 100f;
	public float currentWater = 100f;
	
	private Transform health, food, water;
	private Scrollbar healthBar, foodBar, waterBar;
	private Vector2 healthFullPos, healthEmptyPos;
	private Vector2 foodFullPos, foodEmptyPos;
	private Vector2 waterFullPos, waterEmptyPos;


	void Awake(){
		GameObject heroState = GameObject.Find ("HeroState");
		health = heroState.transform.Find("Health");
		food = heroState.transform.Find("Food");
		water = heroState.transform.Find("Water");

		healthBar = health.GetComponent<Scrollbar> ();
		foodBar = food.GetComponent<Scrollbar> ();
		waterBar = water.GetComponent<Scrollbar> ();
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		healthBar.size = currentHealth / maxHealth;
		foodBar.size = currentFood / maxFood;
		waterBar.size = currentWater / maxWater;
	}
}
