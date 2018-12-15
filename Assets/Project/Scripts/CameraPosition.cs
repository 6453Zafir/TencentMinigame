using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    public float rightDis;//相机右侧范围大小
    public float leftDis;//相机左侧范围大小
    public float moveSpeed;//人物到达边框后相机跟随速度
    public GameObject player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
        if (player.transform.position.x - this.transform.position.x >= rightDis)
        {
            this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);
        }
        else if (player.transform.position.x - this.transform.position.x <= leftDis)
        {
            this.transform.position = new Vector3(this.transform.position.x - moveSpeed, player.transform.position.y, this.transform.position.z);
        }
    }
}