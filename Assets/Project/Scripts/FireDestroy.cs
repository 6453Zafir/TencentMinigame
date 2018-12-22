using System.Collections;
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
            if (this.gameObject.name=="树1")
            {
                var draw= GameObject.Find("树1");
                Destroy(draw);
            }
            else if(this.gameObject.name == "绳子")
            {
                var draw = GameObject.Find("绳子");
                Destroy(draw);
            }
            
        }
       

    }
}
