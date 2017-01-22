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

	public Text scoreText;
	// Use this for initialization
	void Start () {
	    if (GameManager.Instance.player1Lost && GameManager.Instance.player2Lost)
	    {
	        text.text = "It's a Tie!!";

			scoreText.text = "Both kittens got swept into the ocean!";
	    }
	    else if (GameManager.Instance.player2Lost)
	    {
	        text.text = "Jeff From The Overwatch Team Wins!!";

			scoreText.text = "Paw-nzo was swept away!";
	    }
	    else if (GameManager.Instance.player1Lost)
	    {
	        text.text = "Paw-nzo Wins!!";

			scoreText.text = "Jeff From The Overwatch Team was swept away!";
	    }
	    else
	    {
	        if (player1ScoreHigher())
	        {
	            text.text = "Jeff From The Overwatch Team Wins!!";
	        }
	        else if (player2ScoreHigher())
	        {
	            text.text = "Paw-nzo Wins!!";
	        }
	        else text.text = "It's a Tie!!";

			scoreText.text = (int.Parse(GameManager.Instance.Player1ScoreText.text) != 2 ? GameManager.Instance.Player1ScoreText.text : "Two") + " - " + (int.Parse(GameManager.Instance.Player2ScoreText.text) != 2 ? GameManager.Instance.Player2ScoreText.text : "Two");
	    }
	}
	
}
