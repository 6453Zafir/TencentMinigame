using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour {
    /// <summary>
    /// 每张背景图的宽度*3
    /// </summary>
    private float total_length = 86.4f;
	// Use this for initialization
	void Start () {
        Vector3 bgPosition = this.transform.position;
        Vector3 cameraPosition = Camera.main.transform.position; // mainCamera是相机的位置
        bgPosition.y = Camera.main.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 bgPosition = this.transform.position;
        Vector3 cameraPosition = Camera.main.transform.position; // mainCamera是相机的位置

        if (bgPosition.x + total_length / 2.0f < cameraPosition.x)
        {
            bgPosition.x += total_length;
            bgPosition.y = Camera.main.transform.position.y + 5;
            this.transform.position = bgPosition;
        }
        if (bgPosition.x - total_length / 2.0f > cameraPosition.x)
        {
            bgPosition.x -= total_length;
            bgPosition.y = Camera.main.transform.position.y + 5;
            this.transform.position = bgPosition;
        }
    }
}
