using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : UI {


	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			ChangeScene("Game");
		}
		#if UNITY_EDITOR
			if(Input.GetKeyDown(KeyCode.R)){
				ProgressManager.instance.ResetProgress(false);
			}
		#endif
	}

	public void OpenWebsite(){
		Application.OpenURL("https://fog-icmc.itch.io/");
	}

}
