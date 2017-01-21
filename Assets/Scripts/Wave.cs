using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private readonly System.Random rng = new System.Random();
    private double count;
    private double modifier;
    private int surgeTime;
    private bool surge;
    private double surgeDuration = Math.PI * 2;
    private int surgeIntensity;
    private double surgeCounter;
    private float width;
    public float edge;
    public bool waveStop = false;

    public GameObject StartPos;

	// Use this for initialization
	void Start ()
	{
	    if (StartPos != null)
	    {
	        transform.position = StartPos.transform.position;
	        width = GetComponent<SpriteRenderer>().bounds.size.x / 2;
	        edge = transform.position.x + width;
	    }
	    else transform.position = new Vector3(-22.4f, 0f, -5f);

	    resetSurge();

	    StartCoroutine("WaveTiming");

	}

    private void resetSurge()
    {
        surgeTime = rng.Next(5, 15);
        surgeIntensity = rng.Next(2, 4);
        surge = false;
        surgeCounter = -0.25 * Math.PI;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (waveStop) return;
	    if (transform.position.x >= 0)
	    {
	        waveStop = !waveStop;
	        return;
	    }

	    double surgenum = 0;
	    if (surgeTime == 0)
	    {
	        surge = true;
	    }
	    if (surgeCounter >= surgeDuration && surge)
	    {
            resetSurge();
	    }
	    if (surge)
	    {
	        surgenum = Math.Sin(surgeCounter) * surgeIntensity / 50;
	        surgeCounter += 0.04;
	    }

	    double num = Math.Sin(count) / 75 + modifier + surgenum;

        transform.position = new Vector3(transform.position.x + (float)num, 0f, -5f);
	    modifier += 0.000005;
	    count += 0.05;

	    edge = transform.position.x + width;
	}

    IEnumerator WaveTiming()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            surgeTime--;
        }
    }

}
