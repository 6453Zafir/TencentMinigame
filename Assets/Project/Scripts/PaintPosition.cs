using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPosition : MonoBehaviour {

    private Camera paint;
	// Use this for initialization
	void Start () {
        paint = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        paint.orthographicSize = -5 * Camera.main.transform.position.z / 10f;
	}
}
