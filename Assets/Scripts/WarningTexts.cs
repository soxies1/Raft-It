using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningTexts : MonoBehaviour {

	string[] strings = { "Get Back!!", "Come here!", "It's dangerous!", "The shore is safe!", "Nerf the water!!"};
	// Use this for initialization

	Text[] texts;
	void Start(){
		texts = GetComponentsInChildren<Text>();
	}
	bool coroutineStarted = false;
	void Update(){
		if(GameManager.Instance.warning && !coroutineStarted){
			StartCoroutine("StartBlinking");
			coroutineStarted = true;
		}
	}
	
	
	IEnumerator StartBlinking(){
		for(;;){
			Text text = texts[Random.Range(0, texts.Length)];
			text.text = strings[Random.Range(0, strings.Length)];
			yield return new WaitForSeconds(.5f);
			text.text = "";
			yield return new WaitForSeconds(.3f);

			
		}
	}
}
