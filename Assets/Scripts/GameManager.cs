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

    public static bool player1Lost;
    public static bool player2Lost;
    public static bool player1Safe;
    public static bool player2Safe;

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
            DontDestroyOnLoad(transform.gameObject);
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
        float yScale = SpawnArea.transform.localScale.y;
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            float rightEdge = land.getEdge();
            float leftEdge = wave.edge;
            float distance = rightEdge - leftEdge;

            SpawnArea.transform.position = new Vector3(leftEdge + distance / 2, yPos);
            SpawnArea.transform.localScale = new Vector3(distance * 6, yScale);
        }
    }

	IEnumerator SpawnObjects(){
		float spawn = 3f;
		while(true){
			yield return new WaitForSeconds(spawn);
			spawn += .05f;
			SpawnObject();
		    
		}
	}

	void SpawnObject(){
		GameObject objectToSpawn = collectableItems[Random.Range(0, collectableItems.Length)];
		Vector3 tileDimensions = SpawnArea.GetComponent<SpriteRenderer>().bounds.size;
		Vector3 spawnPos = new Vector3(Random.Range(0f, tileDimensions.x) + SpawnArea.transform.position.x, Random.Range(0, tileDimensions.y) - tileDimensions.y/2);
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
