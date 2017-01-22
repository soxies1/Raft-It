using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickUpItem : MonoBehaviour {

	private bool holdingItem = false;

	private GameObject itemHeld;

	AudioSource clip;

	void Start(){
		clip = GetComponent<AudioSource>();
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(!holdingItem && collision.gameObject.tag == "Item"){
			itemHeld = collision.gameObject;
			itemHeld.transform.parent = transform;
			holdingItem = true;
		}

		if(holdingItem && collision.gameObject.tag == "StorageCrate"){
			
			if(collision.gameObject.name == "StorageCrate1"){
				if(!itemHeld.gameObject.name.Contains("Stone")){
					GameManager.Instance.Player1Scores(1);
				}else{
					GameManager.Instance.Player1Scores(-1);
				}
			}else{
				if(!itemHeld.gameObject.name.Contains("Stone")){
					GameManager.Instance.Player2Scores(1);
				}else{
					GameManager.Instance.Player2Scores(-1);
				}
			}
			print(clip);
			if(clip != null){
				clip.Play();
			}

			holdingItem = false;
			Destroy(itemHeld);
			itemHeld = null;
		}
	}
	
}
