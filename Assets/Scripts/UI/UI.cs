using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	public void ToggleWindow(GameObject window){
		window.SetActive(!window.activeSelf);
		//trigger animation
	}

	public void ChangeScene(string scene){
		SceneManager.LoadScene(scene);
	}
}
