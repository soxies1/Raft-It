using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

    public float getEdge()
    {
        return transform.position.x - GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }
}
