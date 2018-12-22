using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticStone : MonoBehaviour {
    private Vector3 pos = new Vector3(466.27f, -0.695f,0);
    private bool ready = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       

	}
    void onCollisionEnter2D(Collision2D other)
    {
        if (!ready)
        {
            var draw1 = GameObject.Find("吊石");
            draw1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
    }
}
