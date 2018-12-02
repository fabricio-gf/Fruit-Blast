using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRepeater : MonoBehaviour {

	private Material material;
	private Vector2 offset;
	private bool isMoving;

	[SerializeField] float backgroundSpeed;

	// Use this for initialization
	void Awake () {
		material = GetComponent<Renderer>().material;
		offset = new Vector2(0, backgroundSpeed);
		transform.localScale = new Vector3(Camera.main.orthographicSize * 2.1f* Screen.width / Screen.height, Camera.main.orthographicSize * 4.0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(isMoving)
			material.mainTextureOffset += offset * Time.deltaTime;
	}

	public void ToggleMoving(){
		isMoving = !isMoving;
	}
}
