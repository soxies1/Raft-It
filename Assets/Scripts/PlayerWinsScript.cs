using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWinsScript : MonoBehaviour
{

    public Text text;
	// Use this for initialization
	void Start () {
	    if (GameManager.player1Lost && GameManager.player2Lost)
	    {
	        text.text = "It's a Tie!!";
	    }
	    else if (GameManager.player2Lost)
	    {
	        text.text = "Player 1 Wins!!";
	    }
	    else if (GameManager.player1Lost)
	    {
	        text.text = "Player 2 Wins!!";
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
