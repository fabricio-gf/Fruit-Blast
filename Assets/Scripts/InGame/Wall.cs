using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	[SerializeField] private bool isRightWall;
	[SerializeField] private bool isKillzone;

	private float horizontalExtent;
	private float verticalExtent;

	void Start(){
		horizontalExtent = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		verticalExtent = Camera.main.orthographicSize;
		if(isRightWall) transform.position = new Vector3(horizontalExtent+0.32f, 0, 0);
		else if(isKillzone) {
			transform.position = new Vector3(0, -verticalExtent-5f, 0);
		}
		else if(!isRightWall && !isKillzone) transform.position = new Vector3(-horizontalExtent-0.32f, 0, 0);
	}

	void Update(){
		if(isKillzone) transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y-verticalExtent-5f, 0);
		else transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, 0);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag != "Rocket") Destroy(other.gameObject);
		else if(!GameManager.instance.victory){
			print("entrou");
			SFXManager.instance.PlayDeathSound();
			other.GetComponent<Rigidbody2D>().gravityScale = 0;
			other.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
	}
}