using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {

	private bool holdingItem = false;

	private GameObject itemHeld;
	
	void OnCollisionEnter2D(Collision2D collision){
		if(!holdingItem && collision.gameObject.tag == "Item"){
			itemHeld = collision.gameObject;
			itemHeld.transform.parent = transform;
			holdingItem = true;
		}

		if(holdingItem && collision.gameObject.tag == "StorageCrate"){
			
			if(collision.gameObject.name == "StorageCrate1"){
				print("player1 scores");
				GameManager.Instance.Player1Scores();
			}else{
				print("player2 scores");
				GameManager.Instance.Player2Scores();
			}

			holdingItem = false;
			Destroy(itemHeld);
			itemHeld = null;
		}
	}
	
}
