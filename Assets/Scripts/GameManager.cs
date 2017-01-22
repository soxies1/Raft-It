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

	public GameObject Player1Prefab, Player2Prefab;

	public Transform Player1Spawn, Player2Spawn;

	static GameManager instance;

    public Wave wave;

	public Land land;

    public bool player1Lost;
    public bool player2Lost;
    public bool player1Safe;
    public bool player2Safe;

	public bool warning = false;

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
		StartCoroutine("SpawnObjects");
		Player1Score = Player2Score = 0;
		UpdateText();

		Instantiate(Player1Prefab, Player1Spawn.position, Quaternion.identity);
		Instantiate(Player2Prefab, Player2Spawn.position, Quaternion.identity);
	}

	IEnumerator SpawnObjects(){
		float spawn = 2.1f;
		while(true){
			yield return new WaitForSeconds(spawn);
			spawn += .1f;
			SpawnObject();
		}
	}

	void SpawnObject(){
		float rightEdge = land.getEdge();
		float leftEdge = wave.edge;

		float distance = rightEdge - leftEdge;
		float middle = leftEdge + distance/2;

		if(distance <= 6f){
			warning = true;
		}

		GameObject objectToSpawn = collectableItems[Random.Range(0, collectableItems.Length)];
		Vector3 spawnPos = new Vector3(Random.Range(leftEdge, rightEdge), Random.Range(-4.5f, 4.5f));
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
