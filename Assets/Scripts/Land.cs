using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float getEdge()
    {
        return transform.position.x - GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }
}
