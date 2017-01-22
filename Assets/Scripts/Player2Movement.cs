using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2Movement : MonoBehaviour {
	public float Speed = 0f;
	private float movex = 0f;
	private float movey = 0f;

	private Rigidbody2D rb;


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
        if (GameManager.Instance.player2Lost)
        {
            movex = -1;
            movey = 0;
            return;
        }
	    if (GameManager.Instance.player2Safe)
	    {
	        movex = 0;
	        movey = 0;
	        return;
	    }

        if (Input.GetKey (KeyCode.LeftArrow))
			movex = -1;
		else if (Input.GetKey (KeyCode.RightArrow))
			movex = 1;
		else
			movex = 0;
		if (Input.GetKey (KeyCode.UpArrow))
			movey = 1;
		else if (Input.GetKey(KeyCode.DownArrow)){
			movey = -1;
		}else{
			movey = 0;
		}
	}

	void FixedUpdate ()
	{
		rb.velocity = new Vector2 (movex * Speed, movey * Speed);
	}
    public void player2Loses()
    {
        GameManager.Instance.player2Lost = true;
        print("collision");
    }

    private void disableCollision()
    {
        GetComponent<Collider2D>().enabled = false;
        var Components = GetComponentsInChildren<Collider2D>();
        foreach (var component in Components)
        {
            component.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDocking(collision))
        {
            GameManager.Instance.player2Safe = true;
            disableCollision();
        }
        if (collision.gameObject.tag == "Waves" && !GameManager.Instance.player1Safe)
        {
            player2Loses();
            disableCollision();
        }
    }

    bool isDocking(Collision2D collision)
    {
        return collision.gameObject.tag == "Dock2";
    }
}
