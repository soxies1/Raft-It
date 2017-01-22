using System.Collections;
using UnityEngine;

public class Wakes : MonoBehaviour {

	public GameObject Wake;

	private Vector3 wakeSize, transformSize;
	
	void Start () {

		transformSize = GetComponent<SpriteRenderer>().bounds.size;

		wakeSize = Wake.GetComponent<SpriteRenderer>().bounds.size;
		StartCoroutine("SpawnWakes");

	}
	

	IEnumerator SpawnWakes(){
		for(;;){
			yield return new WaitForSeconds(Random.Range(.5f, 2f));
			float posx = Random.Range(transformSize.x/4, transformSize.x/2 - wakeSize.x/2);
			float posy = Random.Range(-transformSize.y/2, transformSize.y/2  - wakeSize.y/2);
			Vector3 spawnPos = new Vector3(posx + transform.position.x,posy + transform.position.y, transform.position.z);
			GameObject wake = Instantiate(Wake, spawnPos, Wake.transform.rotation) as GameObject;
			wake.transform.parent = transform;
			Destroy(wake, 3f);
		}
	}
}
