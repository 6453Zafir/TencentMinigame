﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag=="Fire")
        {
            var draw = GameObject.Find("树1");
            Destroy(draw);
        }
       

    }
}
