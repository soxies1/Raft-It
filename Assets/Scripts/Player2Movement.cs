using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2Movement : MonoBehaviour {
	public float Speed = 0f;

    public Canvas overhead;
	private float movex = 0f;
	private float movey = 0f;

	private Rigidbody2D rb;
    private int bounce = 0;
    private Vector3 bounceAngle;

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

        if (bounce > 0)
        {
            movex = bounceAngle.x * 1.5f;
            movey = bounceAngle.y * 1.5f;
            bounce--;

            return;
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
	    movex *= 1.2f;
	    movey *= 1.2f;
	}

	void FixedUpdate ()
	{
		rb.velocity = new Vector2 (movex * Speed, movey * Speed);
	}
    public void player2Loses()
    {
        GameManager.Instance.player2Lost = true;
        overhead.GetComponentInChildren<Text>().text = "AAHHHHHHHH";
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
        if (isDocking(collision) && GameManager.Instance.warning)
        {
            GameManager.Instance.player2Safe = true;
            disableCollision();
        }
        if (collision.gameObject.tag == "Waves" && !GameManager.Instance.player1Safe)
        {
            player2Loses();
            disableCollision();
        }

        if (collision.gameObject.tag == "Player1")
        {
            bounce = 3;
            bounceAngle = new Vector3(collision.contacts.First().point.x, collision.contacts.First().point.y);
            bounceAngle = transform.position - bounceAngle;
            bounceAngle = customNormalize(bounceAngle);
            StartCoroutine(BounceText());
        }

    }

    Vector3 customNormalize(Vector3 v)
    {
        float length = v.x * v.x + v.y * v.y;
        v.x /= length;
        v.y /= length;
        return v;
    }

    bool isDocking(Collision2D collision)
    {
        return collision.gameObject.tag == "Finish";
    }

    IEnumerator BounceText()
    {
        string[] taunts = {"I Do What I Must", "Never In Me-owt", "Never Second Pet", "Flow Like Catnip", "Remember this Meow-ment" };
        int taunt = Random.Range(0, taunts.Length);
        overhead.GetComponentInChildren<Text>().text = taunts[taunt];
        yield return new WaitForSeconds(2);
        if (overhead.GetComponentInChildren<Text>().text == taunts[taunt])
        {
            overhead.GetComponentInChildren<Text>().text = "Paw-nzo";
        }
    }
}
