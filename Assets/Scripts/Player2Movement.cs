﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}