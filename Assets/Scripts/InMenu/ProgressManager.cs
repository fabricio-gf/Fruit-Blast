using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour {

	public static ProgressManager instance;

	[SerializeField] private Unlocks unlocks;
	[SerializeField] private PlayerInfo info;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else if(instance != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		SetUnlocks();
	}

	void Update(){
		#if UNITY_EDITOR
			if(Input.GetKeyDown(KeyCode.R)){
				ResetProgress();
			}
		#endif
	}
	
	void SetUnlocks(){
		info.money = PlayerPrefs.GetInt("Money", 0);
		unlocks.rocketSizeIndex = PlayerPrefs.GetInt("RocketSize", 0);
		unlocks.startingFuelIndex = PlayerPrefs.GetInt("StartingFuel", 0);
		unlocks.fuelConsumptionIndex = PlayerPrefs.GetInt("FuelConsumption", 0);
		unlocks.fruitNumberIndex = PlayerPrefs.GetInt("FruitNumber", 0);
		unlocks.fruitQualityIndex = PlayerPrefs.GetInt("FruitQuality", 0);

	}

	public void ResetProgress(){
		PlayerPrefs.SetInt("Money", 0);
		PlayerPrefs.SetInt("RocketSize", 0);
		PlayerPrefs.SetInt("StartingFuel", 0);
		PlayerPrefs.SetInt("FuelConsumption", 0);
		PlayerPrefs.SetInt("FruitNumber", 0);
		PlayerPrefs.SetInt("FruitQuality", 0);
		SetUnlocks();

		info.money = 0;
		info.rocketSize = unlocks.rocketSizeUnlocks[0];
		info.startingFuel = unlocks.startingFuelUnlocks[0];
		info.fuelConsumption = unlocks.fuelConsumptionUnlocks[0];
		info.fruitNumber = unlocks.fruitNumberUnlocks[0];
		info.fruitQuality = unlocks.fruitQualityUnlocks[0];
		
		PlayerPrefs.Save();
	}

	public void SpendMoney(int value){
		PlayerPrefs.SetInt("Money", info.money - value);
		PlayerPrefs.Save();
		PrintPrefs("Money");
	}

	public void UnlockRocketSize(int value){
		PlayerPrefs.SetInt("RocketSize", value);
		PlayerPrefs.Save();
		PrintPrefs("RocketSize");
	}

	public void UnlockStartingFuel(int value){
		PlayerPrefs.SetInt("StartingFuel", value);
		PlayerPrefs.Save();
		PrintPrefs("StartingFuel");
	}

	public void UnlockFuelConsumption(int value){
		PlayerPrefs.SetInt("FuelConsumption", value);
		PlayerPrefs.Save();
		PrintPrefs("FuelConsumption");
	}

	public void UnlockFruitNumber(int value){
		PlayerPrefs.SetInt("FruitNumber", value);
		PlayerPrefs.Save();
		PrintPrefs("FruitNumber");
	}

	public void UnlockFruitQuality(int value){
		PlayerPrefs.SetInt("FruitQuality", value);
		PlayerPrefs.Save();
		PrintPrefs("FruitQuality");
	}

	// debug
	private void PrintPrefs(string str){
		print(str + " prefs " + PlayerPrefs.GetInt(str));
	}
}
