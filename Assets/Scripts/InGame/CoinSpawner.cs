using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	[Header("References")]
	[SerializeField] private GameObject coinPrefab;
	[SerializeField] private GameObject rocket;
	private Transform rocketTransform;
	private RocketMovement rocketMovement;
	[SerializeField] private Transform _dynamic;

	[Header("Attributes")]
	[SerializeField] private Vector3[] coinOffsets;
	[SerializeField] private Transform[] spawnPositions;

	// Use this for initialization
	void Awake () {
		//rocketTransform = rocket.transform;
		//rocketMovement = rocket.GetComponent<RocketMovement>();
	}

	void Start(){
		
	}

	public void StartSpawningCoins(){
		InvokeRepeating("SpawnCoins", 0, 3f);
	}
	
	void SpawnCoins(){
		int randomIndex = Random.Range(0, coinOffsets.Length);

		Vector3 spawnPosition = Camera.main.transform.position + spawnPositions[Random.Range(0, spawnPositions.Length)].position;

		for(int i = 0; i < coinOffsets[randomIndex].z; i++){
			Instantiate(coinPrefab, spawnPosition, Quaternion.identity, _dynamic);
			spawnPosition += new Vector3(coinOffsets[randomIndex].x, coinOffsets[randomIndex].y, 0);
		}
	}
}
