using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour {

    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < -2)
        {
            this.transform.position = new Vector2(160, 26);
        }

    }
}
