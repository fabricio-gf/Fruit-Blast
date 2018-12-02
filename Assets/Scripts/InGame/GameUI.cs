using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UI {

	[Header("References")]
	[SerializeField] private PlayerInfo info;
	[SerializeField] private Unlocks unlocks;
	
	[SerializeField] private GameObject rocket;
	private RocketMovement rocketMovement;
	public GameObject actionButton;
	[SerializeField] private Text altitudeText;

	[SerializeField] private Image fuelBar;
	[SerializeField] private Sprite[] fuelBarSprites;
	[SerializeField] private Image fuelBarFront;
	[SerializeField] private Sprite[] fuelBarFrontSprites;
	[SerializeField] private float[] fuelBarFrontValues;

	[SerializeField] private Text moneyText;
	[SerializeField] private GameObject warningText;

	[SerializeField] private Text endAltitudeText;
	[SerializeField] private Text endMoneyText;

	[SerializeField] private GameObject endWindow;
	[SerializeField] private GameObject buttons;
	[SerializeField] private GameObject launchButton;

	[SerializeField] private GameObject victoryWindow;

	void Awake(){
		rocketMovement = rocket.GetComponent<RocketMovement>();
	}

	public void InitializeInvokes(){
		InvokeRepeating("UpdateAltitude", 0, 0.1f);
		InvokeRepeating("UpdateFuel", 0, 0.1f);
		
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

	public void TransferButtonLeft(){
		rocketMovement.TransferMovementLeft();
	}

	public void TransferButtonRight(){

		rocketMovement.TransferMovementRight();
	}

	public void ToggleActionButton(){

		warningText.SetActive(!warningText.activeSelf);
		actionButton.SetActive(!actionButton.activeSelf);
		//button animation
	}

	private void UpdateAltitude(){

		if(rocket.transform.position.y <= 0) altitudeText.text = "Altitude: 0m"; 
		else altitudeText.text = "Altitude: " + System.Math.Round(rocket.transform.position.y, 2).ToString() + "m";
	}

	private void UpdateFuel(){

		//fuelText.text = "Fuel:\n" + System.Math.Round(rocketMovement.fuelAmmount, 2).ToString();
		fuelBarFront.transform.localScale = new Vector3(rocketMovement.fuelAmmount/rocketMovement.initialFuelAmmount, 0.85f, 1);
	}

	public void UpdateMoney(int value){

		moneyText.text = value.ToString();
	}

	public void ToggleEndWindow(float altitude){

		EndMethods();
		endAltitudeText.text = "You've reached " + System.Math.Round(altitude, 2).ToString() + "m";
		endMoneyText.text = "You have " + info.money.ToString() + " coins";
		endWindow.SetActive(!endWindow.activeSelf);
	}

	public void ToggleVictoryWindow(){

		EndMethods();
		victoryWindow.SetActive(!victoryWindow.activeSelf);
	}

	private void EndMethods(){

		CancelInvoke();
		ToggleButtons();
	}

	public void ToggleButtons(){

		buttons.SetActive(!buttons.activeSelf);
	}
	
	public void ToggleLaunchButton(){

		launchButton.SetActive(!launchButton.activeSelf);
	}

	public void SetFuelBar(){

		int index = unlocks.startingFuelIndex;
		fuelBar.sprite = fuelBarSprites[index];
		fuelBar.GetComponent<RectTransform>().sizeDelta = new Vector2(250*(index+2),100);
		fuelBarFront.sprite = fuelBarFrontSprites[index];
		fuelBarFront.GetComponent<RectTransform>().sizeDelta = new Vector2(fuelBarFrontValues[index],100);
	}

}
