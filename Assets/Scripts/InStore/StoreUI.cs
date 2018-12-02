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
			ProgressManager.instance.SpendMoney(unlocks.rocketSizePrices[unlocks.rocketSizeIndex]);
			
			unlocks.rocketSizeIndex++;
			int index = unlocks.rocketSizeIndex;

			info.rocketSize = unlocks.rocketSizeUnlocks[index];
			
			SFXManager.instance.PlaySelectSound();

			ProgressManager.instance.UnlockRocketSize(index);

			UpdateUI();
		}
	}

	public void UnlockStartingFuel(){
		if(unlocks.startingFuelIndex + 1 < unlocks.startingFuelUnlocks.Length && unlocks.startingFuelPrices[unlocks.startingFuelIndex] < info.money){
			info.money -= unlocks.startingFuelPrices[unlocks.startingFuelIndex];
			ProgressManager.instance.SpendMoney(unlocks.startingFuelPrices[unlocks.startingFuelIndex]);

			unlocks.startingFuelIndex++;
			int index = unlocks.startingFuelIndex;

			info.startingFuel = unlocks.startingFuelUnlocks[index];

			SFXManager.instance.PlaySelectSound();

			ProgressManager.instance.UnlockStartingFuel(index);

			UpdateUI();
		}
	}

	public void UnlockFuelConsumption(){
		if(unlocks.fuelConsumptionIndex + 1 < unlocks.fuelConsumptionUnlocks.Length && unlocks.fuelConsumptionPrices[unlocks.fuelConsumptionIndex] < info.money){
			info.money -= unlocks.fuelConsumptionPrices[unlocks.fuelConsumptionIndex];
			ProgressManager.instance.SpendMoney(unlocks.fuelConsumptionPrices[unlocks.fuelConsumptionIndex]);

			unlocks.fuelConsumptionIndex++;
			int index = unlocks.fuelConsumptionIndex;

			info.fuelConsumption = unlocks.fuelConsumptionUnlocks[index];

			SFXManager.instance.PlaySelectSound();

			ProgressManager.instance.UnlockFuelConsumption(index);

			UpdateUI();
		}
	}

	public void UnlockFruitNumber(){
		if(unlocks.fruitNumberIndex + 1 < unlocks.fruitNumberUnlocks.Length && unlocks.fruitNumberPrices[unlocks.fruitNumberIndex] < info.money){
			info.money -= unlocks.fruitNumberPrices[unlocks.fruitNumberIndex];
			ProgressManager.instance.SpendMoney(unlocks.fruitNumberPrices[unlocks.fruitNumberIndex]);

			unlocks.fruitNumberIndex++;
			int index = unlocks.fruitNumberIndex;

			info.fruitNumber = unlocks.fruitNumberUnlocks[index];

			SFXManager.instance.PlaySelectSound();

			ProgressManager.instance.UnlockFruitNumber(index);

			UpdateUI();
		}
	}

	public void UnlockFruitQuality(){
		if(unlocks.fruitQualityIndex + 1 < unlocks.fruitQualityUnlocks.Length && unlocks.fruitQualityPrices[unlocks.fruitQualityIndex] < info.money){
			info.money -= unlocks.fruitQualityPrices[unlocks.fruitQualityIndex];
			ProgressManager.instance.SpendMoney(unlocks.fruitQualityPrices[unlocks.fruitQualityIndex]);

			unlocks.fruitQualityIndex++;
			int index = unlocks.fruitQualityIndex;

			info.fruitQuality = unlocks.fruitQualityUnlocks[index];

			SFXManager.instance.PlaySelectSound();

			ProgressManager.instance.UnlockFruitQuality(index);

			UpdateUI();
		}
	}

	private void ResetUpgrades(){
		ProgressManager.instance.ResetProgress();
	}
}
