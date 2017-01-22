using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

	Canvas canvas;

	bool coroutineStarted = false;
	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}

	void Update(){
		if(GameManager.Instance.warning && !coroutineStarted){
			StartCoroutine("StartBlinking");
			coroutineStarted = true;
		}
	}
	
	
	IEnumerator StartBlinking(){
		for(;;){
			canvas.enabled = true;
			yield return new WaitForSeconds(.6f);
			canvas.enabled = false;
			yield return new WaitForSeconds(.6f);
		}
	}
}
