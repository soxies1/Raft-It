using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player1Movement : MonoBehaviour {
	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;

	private Rigidbody2D rb;

    public Wave wave;

// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

// Update is called once per frame
	void Update () {

	    if (transform.position.x < -12)
	    {
            SceneManager.LoadScene("GameOver");
        }

	    if (GameManager.player1Lost)
	    {
	        movex = -1;
	        return;
	    }
		if (Input.GetKey (KeyCode.A))
			movex = -1;
		else if (Input.GetKey (KeyCode.D))
			movex = 1;
		else
			movex = 0;
		if (Input.GetKey (KeyCode.W))
			movey = 1;
		else if (Input.GetKey(KeyCode.S)){
			movey = -1;
		}else{
			movey = 0;
		}
	}

	void FixedUpdate ()
	{
		rb.velocity = new Vector2 (movex * Speed, movey * Speed);
	}

    public void player1Loses()
    {
        GameManager.player1Lost = true;
        print("collision");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Waves")
        {
            player1Loses();
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
