using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {

	
	public GameObject[] collectableItems;

	public Text Player1ScoreText;

	public Text Player2ScoreText;

	private int Player1Score, Player2Score;

	private GameObject SpawnArea;

	public GameObject Player1Prefab, Player2Prefab;

	public Transform Player1Spawn, Player2Spawn;

	static GameManager instance;

    public Wave wave;

	public Land land;

	public static GameManager Instance{
		get{
			if(instance == null){
				instance = GameObject.FindObjectOfType<GameManager>();

				if(instance == null){
					instance = new GameObject().AddComponent<GameManager>();
				}
			}
			return instance;
		}
	}

	void Awake(){
		if (instance == null){
			instance = this;
		}else{
			Destroy(gameObject);
		}
	}

	void Start(){
		SpawnArea = GameObject.FindGameObjectWithTag("SpawnArea");
		StartCoroutine("SpawnObjects");
	    StartCoroutine("CalculateSpawnArea");
		Player1Score = Player2Score = 0;
		UpdateText();

		Instantiate(Player1Prefab, Player1Spawn.position, Quaternion.identity);
		Instantiate(Player2Prefab, Player2Spawn.position, Quaternion.identity);
	}

    IEnumerator CalculateSpawnArea()
    {
        float yPos = SpawnArea.transform.position.y;
        float zPos = SpawnArea.transform.position.z;
        float yScale = SpawnArea.transform.localScale.y;
        float zScale = SpawnArea.transform.localScale.z;
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            float rightEdge = land.getEdge();
            float leftEdge = wave.edge;
            float distance = rightEdge - leftEdge;

            SpawnArea.transform.position = new Vector3(leftEdge + distance / 2, yPos);
//            SpawnArea.GetComponent<SpriteRenderer>().bounds.size.x = distance;
//            SpawnArea.transform.localScale = new Vector3(distance * 2,yScale,zScale);
            SpawnArea.transform.localScale = new Vector3(distance * 6, yScale);
//            print("Scale" + distance);
        }
    }

	IEnumerator SpawnObjects(){
		float spawn = 4f;
		while(true){
			yield return new WaitForSeconds(spawn);
			spawn += .05f;
			SpawnObject();
		    
		}
	}

	void SpawnObject(){
		GameObject objectToSpawn = collectableItems[Random.Range(0, collectableItems.Length)];
		Vector3 tileDimensions = SpawnArea.GetComponent<SpriteRenderer>().bounds.size;
//		Vector3 tileDimensions = new Vector3(SpawnArea.transform.localScale.x, SpawnArea.transform.localScale.y);
//	    tileDimensions.x += SpawnArea.transform.position.x;
        print("x" + tileDimensions.x);
//		Vector3 spawnPos = new Vector3(Random.Range(0f, tileDimensions.x) - tileDimensions.x/2, Random.Range(0, tileDimensions.y) - tileDimensions.y/2);
		Vector3 spawnPos = new Vector3(Random.Range(0f, tileDimensions.x) + SpawnArea.transform.position.x, Random.Range(0, tileDimensions.y) - tileDimensions.y/2);
//        SpawnArea.transform.position = new Vector3(wave.edge, transform.position.y, transform.position.z);
        Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
	}

	public void Player1Scores(){
		Player1Score++;
		UpdateText();
	}

	public void Player2Scores(){
		Player2Score++;
		UpdateText();
	}

	void UpdateText(){
		Player1ScoreText.text = Player1Score.ToString();
		Player2ScoreText.text = Player2Score.ToString();
	}
}
