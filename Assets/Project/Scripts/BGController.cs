using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {
    private float total_length = 172.8f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 bgPosition = this.transform.position;
        Vector3 cameraPosition = Camera.main.transform.position; // mainCamera是相机的位置
        if (bgPosition.x + total_length / 2.0f < cameraPosition.x)
        {
            bgPosition.x += total_length;
            this.transform.position = bgPosition;
        }
        if (bgPosition.x - total_length / 2.0f > cameraPosition.x)
        {
            bgPosition.x -= total_length;
            this.transform.position = bgPosition;
        }
    }
}
