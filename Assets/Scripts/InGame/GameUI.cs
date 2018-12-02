using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UI {

	[Header("References")]
	[SerializeField] private PlayerInfo info;
	
	[SerializeField] private GameObject rocket;
	private RocketMovement rocketMovement;
	[SerializeField] private GameObject actionButton;
	[SerializeField] private Text altitudeText;
	[SerializeField] private Text fuelText;
	[SerializeField] private Text moneyText;

	[SerializeField] private Text endAltitudeText;
	[SerializeField] private Text endMoneyText;

	[SerializeField] private GameObject endWindow;
	[SerializeField] private GameObject buttons;
	[SerializeField] private GameObject launchButton;

	void Awake(){
		rocketMovement = rocket.GetComponent<RocketMovement>();
	}

	void Start(){
		InvokeRepeating("UpdateAltitude", 0, 0.1f);
		InvokeRepeating("UpdateFuel", 0, 0.1f);
	}

	void FixedUpdate(){
	}

	public void RightButton(){
		rocketMovement.GoRight();
	}

	public void LeftButton(){
		rocketMovement.GoLeft();
	}

	public void ReleaseButton(){
		rocketMovement.StopMovement();
	}

	public void ToggleActionButton(){
		actionButton.SetActive(!actionButton.activeSelf);
		//button animation
	}

	private void UpdateAltitude(){
		altitudeText.text = "Altitude:\n" + System.Math.Round(rocket.transform.position.y, 2).ToString();
	}

	private void UpdateFuel(){
		fuelText.text = "Fuel:\n" + System.Math.Round(rocketMovement.fuelAmmount, 2).ToString();
	}

	public void UpdateMoney(int value){
		moneyText.text = "Money:\n" + value;
	}

	public void ToggleEndWindow(float altitude){
		ToggleButtons();
		endAltitudeText.text = "You've reached " + System.Math.Round(altitude, 2).ToString() + "m";
		endMoneyText.text = "You have " + info.money.ToString() + " coins";
		endWindow.SetActive(!endWindow.activeSelf);
	}

	public void ToggleButtons(){
		buttons.SetActive(!buttons.activeSelf);
	}
	
	public void ToggleLaunchButton(){
		launchButton.SetActive(!launchButton.activeSelf);
	}
}
