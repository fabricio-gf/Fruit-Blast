using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[Header("References")]
	[SerializeField] private Transform rocket;
	private RocketMovement rocketMovement;

	[Header("Attributes")]
	[SerializeField] private float cameraOffsetY;
	

	void Awake(){
		rocketMovement = rocket.GetComponent<RocketMovement>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(rocketMovement.isFlying && !GameManager.instance.victory){
			transform.position = new Vector3(0, rocket.position.y + cameraOffsetY, -10);
		}
	}

	void ScreenShake(int intensity){

	}
}
