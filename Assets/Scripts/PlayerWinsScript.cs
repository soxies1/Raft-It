using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWinsScript : MonoBehaviour
{

    bool player1ScoreHigher()
    {
        return int.Parse(GameManager.Instance.Player1ScoreText.text) >
               int.Parse(GameManager.Instance.Player2ScoreText.text);
    }

    bool player2ScoreHigher()
    {
        return int.Parse(GameManager.Instance.Player1ScoreText.text) <
               int.Parse(GameManager.Instance.Player2ScoreText.text);
    }

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
	    else
	    {
	        if (player1ScoreHigher())
	        {
	            text.text = "Player 1 Wins!!";
	        }
	        else if (player2ScoreHigher())
	        {
	            text.text = "Player 2 Wins!!";
	        }
	        else text.text = "It's a Tie!!";
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
