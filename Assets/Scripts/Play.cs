using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour {

	public void PlayClicked(){
		SceneManager.LoadScene(2);
	}

	void Update(){
		if(Input.GetKey(KeyCode.Return)) PlayClicked();
	}
}
