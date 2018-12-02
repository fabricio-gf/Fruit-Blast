using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUI : UI {

	[Header("References")]
	[SerializeField] private PlayerInfo info;
	[SerializeField] private Unlocks unlocks;

	void Update(){
#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.R)){
			ResetUpgrades();
		}
#endif
	}
	
	private void UpdateUI(){

	}

	public void UnlockRocketSize(){
		if(unlocks.rocketSizeIndex + 1 < unlocks.rocketSizeUnlocks.Length && unlocks.rocketSizePrices[unlocks.rocketSizeIndex] < info.money){
			info.money -= unlocks.rocketSizePrices[unlocks.rocketSizeIndex];
			
			int index = unlocks.rocketSizeIndex++;
			info.rocketSize = unlocks.rocketSizeUnlocks[index];
			
			InGameSFX.instance.PlaySelectSound();

			UpdateUI();
		}
	}

	public void UnlockStartingFuel(){
		if(unlocks.startingFuelIndex + 1 < unlocks.startingFuelUnlocks.Length && unlocks.startingFuelPrices[unlocks.startingFuelIndex] < info.money){
			info.money -= unlocks.startingFuelPrices[unlocks.startingFuelIndex];
			
			int index = unlocks.startingFuelIndex++;
			info.startingFuel = unlocks.startingFuelUnlocks[index];

			InGameSFX.instance.PlaySelectSound();

			UpdateUI();
		}
	}

	public void UnlockFuelConsumption(){
		if(unlocks.fuelConsumptionIndex + 1 < unlocks.fuelConsumptionUnlocks.Length && unlocks.fuelConsumptionPrices[unlocks.fuelConsumptionIndex] < info.money){
			info.money -= unlocks.fuelConsumptionPrices[unlocks.fuelConsumptionIndex];
			
			int index = unlocks.fuelConsumptionIndex++;
			info.fuelConsumption = unlocks.fuelConsumptionUnlocks[index];

			InGameSFX.instance.PlaySelectSound();

			UpdateUI();
		}
	}

	public void UnlockFruitNumber(){
		if(unlocks.fruitNumberIndex + 1 < unlocks.fruitNumberUnlocks.Length && unlocks.fruitNumberPrices[unlocks.fruitNumberIndex] < info.money){
			info.money -= unlocks.fruitNumberPrices[unlocks.fruitNumberIndex];
			unlocks.fruitNumberIndex++;
			int index = unlocks.fruitNumberIndex;
			info.fruitNumber = unlocks.fruitNumberUnlocks[index];

			InGameSFX.instance.PlaySelectSound();

			UpdateUI();
		}
	}

	public void UnlockFruitQuality(){
		if(unlocks.fruitQualityIndex + 1 < unlocks.fruitQualityUnlocks.Length && unlocks.fruitQualityPrices[unlocks.fruitQualityIndex] < info.money){
			info.money -= unlocks.fruitQualityPrices[unlocks.fruitQualityIndex];
			
			int index = unlocks.fruitQualityIndex++;
			info.fruitQuality = unlocks.fruitQualityUnlocks[index];

			InGameSFX.instance.PlaySelectSound();

			UpdateUI();
		}
	}

	private void ResetUpgrades(){
		unlocks.rocketSizeIndex = 0;
		info.rocketSize = unlocks.rocketSizeUnlocks[0];
		unlocks.startingFuelIndex = 0;
		info.startingFuel = unlocks.startingFuelUnlocks[0];
		unlocks.fuelConsumptionIndex = 0;
		info.fuelConsumption = unlocks.fuelConsumptionUnlocks[0];
		unlocks.fruitNumberIndex = 0;
		info.fruitNumber = unlocks.fruitNumberUnlocks[0];
		unlocks.fruitQualityIndex = 0;
		info.fruitQuality = unlocks.fruitQualityUnlocks[0];
	}
}
