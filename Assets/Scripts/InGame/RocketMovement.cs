using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour {

	[Header("DEBUG")]
	public KeyCode launchKey;

	[Header("References")]
	private Rigidbody2D rigidBody;
	[SerializeField] GameUI gameUI;
	[SerializeField] PlayerInfo info;
	[SerializeField] CoinSpawner coinSpawner;

	[Header("Attributes")]
	[SerializeField] private float flightVelocity;
	public float fuelAmmount;
	private float initialFuelAmmount;
	private bool actionButtonToggled = false;
	[SerializeField] private float fuelDepletionRate;
	[SerializeField] private float fruitFuelGain;

	[SerializeField] private float turnVelocity;
	public bool isFlying = false;
	public bool launchEnded = false;
	private bool isLeftPressed = false;
	private bool isRightPressed = false;
	private int currentFruit;

	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody2D>();
		initialFuelAmmount = fuelAmmount;
	}

	void Start(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!launchEnded && !isFlying && Input.GetKeyDown(launchKey)){
			LaunchRocket();
		}
		if(!launchEnded && isFlying && actionButtonToggled && Input.GetKeyDown(launchKey)){
			Action();
		}

		if(isRightPressed) rigidBody.velocity = new Vector2(-turnVelocity, rigidBody.velocity.y);
		else if(isLeftPressed) rigidBody.velocity = new Vector2(turnVelocity, rigidBody.velocity.y);
		else if(!isRightPressed && !isLeftPressed && isFlying) rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*turnVelocity, rigidBody.velocity.y);
	}

	void FixedUpdate(){
		if(isFlying && fuelAmmount > 0){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, flightVelocity);
			fuelAmmount -= fuelDepletionRate;
			if(fuelAmmount <= initialFuelAmmount*fuelDepletionRate && !actionButtonToggled){
				actionButtonToggled = true;
				gameUI.ToggleActionButton();
			}
			else if(fuelAmmount <= 0){
				GameManager.instance.EndLaunch(transform.position.y);
				isFlying = false;
				launchEnded = true;
				actionButtonToggled = false;
				gameUI.ToggleActionButton();
			}
		}
	}

	public void LaunchRocket(){
		//rocket buildup
		isFlying = true;
		gameUI.ToggleLaunchButton();
		coinSpawner.StartSpawningCoins();
	}

	public void GoRight(){
		if(isFlying){
			isLeftPressed = true;
		}
	}

	public void GoLeft(){
		if(isFlying){
			isRightPressed = true;
		}
	}

	public void StopMovement(){
		isRightPressed = false;
		isLeftPressed = false;
	}

	public void IncrementMoney(){
		info.money++;
		gameUI.UpdateMoney(info.money);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Coin"){
			IncrementMoney();
			InGameSFX.instance.PlayCoinSound();
			Destroy(other.gameObject);
		}
	}

	public void ResetAttributes(){
		currentFruit = info.fruitNumber;
		fuelAmmount = initialFuelAmmount;
		GetComponent<Rigidbody2D>().gravityScale = 2;
		launchEnded = false;
	}

	void Action(){
		if(info.rocketSize > 1){
			//latch rocket
			//info.rocketSize--;
			actionButtonToggled = false;
			gameUI.ToggleActionButton();
		}
		else if(currentFruit > 0){
			InGameSFX.instance.PlaySacrificeSound();
			currentFruit--;
			fuelAmmount += info.fruitQuality*fruitFuelGain;
			if(fuelAmmount > info.startingFuel) fuelAmmount = info.startingFuel;
			GameManager.instance.LoseFruit();
			actionButtonToggled = false;
			gameUI.ToggleActionButton();
		}
		
	}
}
