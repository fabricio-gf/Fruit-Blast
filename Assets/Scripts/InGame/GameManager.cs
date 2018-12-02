using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[Header("References")]
	[SerializeField] private PlayerInfo info;
	[SerializeField] private GameUI gameUI;
	[SerializeField] private GameObject rocket;
	private RocketMovement rocketMovement;
	[SerializeField] private GameObject[] astroObjects;
	[SerializeField] private Sprite[] fruitSprites;
	[SerializeField] private Sprite[] fruitSpritesTier2;
	private int fruitIndex;
	[SerializeField] private CoinSpawner coinSpawner;

	[Header("Attributes")]
	[SerializeField] private Transform launchPosition;
	[SerializeField] private float endDelay;

	// Use this for initialization
	void Awake () {
		if(instance == null){
			instance = this;
		}
		else if(instance != this){
			Destroy(gameObject);
		}
		rocketMovement = rocket.GetComponent<RocketMovement>();
	}

	void Start(){
		InitializeLaunch();
	}

	public void InitializeLaunch(){
		rocket.transform.position = launchPosition.position;
		RandomizeFruits();
		Camera.main.transform.position = new Vector3(0, 0, -10);
		//update rocket number
		rocketMovement.ResetAttributes();
		gameUI.ToggleButtons();
		gameUI.ToggleLaunchButton();
		gameUI.SetFuelBar();
		gameUI.UpdateMoney(info.money);
		gameUI.InitializeInvokes();
		//reset UI
		
	}

	public void RandomizeFruits(){
		fruitIndex = info.fruitNumber;
		for(int i = 0; i < info.fruitNumber; i++){
			switch(info.fruitQuality){
				case 1:
					astroObjects[i].GetComponent<SpriteRenderer>().sprite = fruitSprites[Random.Range(0,fruitSprites.Length)];
					astroObjects[i].SetActive(true);
				break;
				case 2:
					astroObjects[i].GetComponent<SpriteRenderer>().sprite = fruitSpritesTier2[Random.Range(0,fruitSpritesTier2.Length)];
					astroObjects[i].SetActive(true);
				break;
			}
		}
	}

	public void LoseFruit(){
		fruitIndex--;
		if(fruitIndex >= 0)
			astroObjects[fruitIndex].SetActive(false);
	}

	public void EndLaunch(float altitude){
		StartCoroutine(EndDelay(endDelay, altitude));
		coinSpawner.CancelInvoke();
	}

	IEnumerator EndDelay(float endDelay, float altitude){
		yield return new WaitForSeconds(endDelay);
		gameUI.ToggleEndWindow(altitude);
	}
}
