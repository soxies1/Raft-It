using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("RestartGame");
	}

	IEnumerator RestartGame(){
		yield return new WaitForSeconds(5f);
		Destroy(GameManager.Instance);
		SceneManager.LoadScene(0);
	}
	
}
