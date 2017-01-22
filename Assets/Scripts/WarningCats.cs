using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningCats : MonoBehaviour {
	
	public float speed;
	public Transform pos;
	
	void Update () {
		if(GameManager.Instance.warning){
			if(transform.position.x > pos.position.x){
				Vector3 newPos = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
				transform.position = newPos;
			}
		}
	}
}
