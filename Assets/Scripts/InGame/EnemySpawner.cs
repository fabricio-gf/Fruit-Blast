using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


	[Header("References")]
	[SerializeField] private GameObject enemyPrefab;
	[SerializeField] private GameObject rocket;
	private Transform rocketTransform;
	private RocketMovement rocketMovement;
	[SerializeField] private Transform _dynamic;

	[Header("Attributes")]
	[SerializeField] private Transform[] spawnPositions;
	[SerializeField] private float spawnDelay = 5f;

	// Use this for initialization
	void Awake () {
		//rocketTransform = rocket.transform;
		rocketMovement = rocket.GetComponent<RocketMovement>();
	}
	public void StartSpawningCoins(){
		InvokeRepeating("SpawnEnemies", 0, spawnDelay);
	}
	
	void SpawnEnemies(){
		
		if(!GameManager.instance.victory && rocketMovement.isFlying){

			Vector3 pos = Camera.main.transform.position + spawnPositions[Random.Range(0, spawnPositions.Length)].position;

			Instantiate(enemyPrefab, pos, Quaternion.identity, _dynamic);
		}
	}
}
