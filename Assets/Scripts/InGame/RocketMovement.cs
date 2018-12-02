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
	private Animator animator;
	[SerializeField] private GameObject fireStrong;
	[SerializeField] private GameObject fireWeak;
	[SerializeField] private TextureRepeater background;

	[Header("Attributes")]
	[SerializeField] private float flightVelocity;
	public float fuelAmmount;
	[HideInInspector] public float initialFuelAmmount;
	private bool actionButtonToggled = false;
	[SerializeField] private float fuelDepletionRate;
	[SerializeField] private float fruitFuelGain;

	[SerializeField] private float turnVelocity;
	public bool isFlying = false;
	public bool launchEnded = false;
	private bool isLeftPressed = false;
	private bool isRightPressed = false;
	private int currentFruit;
	[SerializeField] private float launchSequenceDelay;
	[SerializeField] private float strongFireDelay;

	// Use this for initialization
	void Awake () {
		rigidBody = GetComponent<Rigidbody2D>();
		initialFuelAmmount = fuelAmmount;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M)){
			SFXManager.instance.ToggleMute();
		}
		if(!launchEnded && !isFlying && Input.GetKeyDown(launchKey)){
			StartCoroutine(LaunchSequence());
		}
		if(!launchEnded && isFlying && actionButtonToggled && Input.GetKeyDown(launchKey)){
			Action();
		}

		if(!GameManager.instance.victory){
			if(isRightPressed){ 
				rigidBody.velocity = new Vector2(turnVelocity, rigidBody.velocity.y);
				animator.SetBool("TurnLeft", false);
				animator.SetBool("TurnRight", true);
			}
			else if(isLeftPressed) {
				rigidBody.velocity = new Vector2(-turnVelocity, rigidBody.velocity.y);
				animator.SetBool("TurnRight", false);
				animator.SetBool("TurnLeft", true);
			}
			else if(!isRightPressed && !isLeftPressed && isFlying) {
				rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*turnVelocity, rigidBody.velocity.y);
				if(Input.GetAxisRaw("Horizontal") > 0.1){
					animator.SetBool("TurnLeft", false);			
					animator.SetBool("TurnRight", true);

				}
				else if(Input.GetAxisRaw("Horizontal") < -0.1){
					animator.SetBool("TurnRight", false);
					animator.SetBool("TurnLeft", true);
				}
				else{
					animator.SetBool("TurnLeft", false);
					animator.SetBool("TurnRight", false);
				}
			}
			else{
				animator.SetBool("TurnLeft", false);
				animator.SetBool("TurnRight", false);
			}
		}

		
	}

	void FixedUpdate(){
		if(isFlying && fuelAmmount > 0 && !GameManager.instance.victory){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, flightVelocity);
			fuelAmmount -= fuelDepletionRate;
			if(fuelAmmount <= initialFuelAmmount*fuelDepletionRate && !actionButtonToggled){
				actionButtonToggled = true;
				gameUI.ToggleActionButton();
			}
			else if(fuelAmmount <= 0){
				GameManager.instance.EndLaunch(transform.position.y);
				isFlying = false;
				isRightPressed = false;
				isLeftPressed = false;
				launchEnded = true;
				actionButtonToggled = false;
				DeactivateFires();
				gameUI.ToggleActionButton();
				background.ToggleMoving();
			}
		}
		
	}

	IEnumerator LaunchSequence(){

		SFXManager.instance.PlayLaunchSound();
		fireStrong.SetActive(true);
		gameUI.ToggleLaunchButton();
		yield return new WaitForSeconds(launchSequenceDelay);
		LaunchRocket();
		StartCoroutine(StrongFireWait());
	}

	IEnumerator StrongFireWait(){

		yield return new WaitForSeconds(strongFireDelay);
		fireStrong.SetActive(false);
		fireWeak.SetActive(true);
	}

	public void LaunchButton(){

		StartCoroutine(LaunchSequence());
	}

	public void LaunchRocket(){

		//rocket buildup
		isFlying = true;
		background.ToggleMoving();
		coinSpawner.StartSpawningCoins();
	}

	public void GoRight(){

		if(isFlying){
			isRightPressed = true;
		}
	}

	public void GoLeft(){

		if(isFlying){
			isLeftPressed = true;
		}
	}

	public void StopMovement(){

		isRightPressed = false;
		isLeftPressed = false;
	}

	public void TransferMovementLeft(){

		if(isRightPressed && isFlying){
			isLeftPressed = true;
			isRightPressed = false;
		}
	}

	public void TransferMovementRight(){

		if(isLeftPressed && isFlying){
			isLeftPressed = false;
			isRightPressed = true;
		}
	}

	public void IncrementMoney(){

		info.money++;
		gameUI.UpdateMoney(info.money);
	}

	public void ResetAttributes(){

		isFlying = false;
		currentFruit = info.fruitNumber;
		fuelAmmount = initialFuelAmmount;
		fuelDepletionRate = info.fuelConsumption;
		GetComponent<Rigidbody2D>().gravityScale = 2;
		launchEnded = false;
	}

	public void Action(){
	
		/* if(info.rocketSize > 1){
			//latch rocket
			//info.rocketSize--;
			actionButtonToggled = false;
			gameUI.ToggleActionButton();
		}
		else*/ if(currentFruit > 0){
			SFXManager.instance.PlaySacrificeSound();
			currentFruit--;
			fuelAmmount = info.fruitQuality*fruitFuelGain;
			if(fuelAmmount > info.startingFuel) fuelAmmount = info.startingFuel;
			GameManager.instance.LoseFruit();
			actionButtonToggled = false;
			gameUI.ToggleActionButton();
		}
		
	}

	public void DeactivateFires(){

		fireWeak.SetActive(false);
		fireStrong.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Coin"){
			IncrementMoney();
			SFXManager.instance.PlayCoinSound();
			Destroy(other.gameObject);
		}

		else if(other.tag == "Enemy"){
			//play crash sound
			GameManager.instance.EndLaunch(transform.position.y);
			isFlying = false;
			isRightPressed = false;
			isLeftPressed = false;
			launchEnded = true;
			actionButtonToggled = false;
			DeactivateFires();
			if(!gameUI.actionButton.activeSelf) gameUI.ToggleActionButton();
			background.ToggleMoving();
		}
	}
}
