using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Update(){
		if(Input.GetKey(KeyCode.Return)) PlayClicked();
	}
	public void PlayClicked(){
		SceneManager.LoadScene(1);
	}

	public void ExitClicked(){
		Application.Quit();
	}
}
