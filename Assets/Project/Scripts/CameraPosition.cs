using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {
    public float yOffest = 2.87f;
    public float xOffest = 5f;
    public float rightDis;//相机右侧范围大小
    public float leftDis;//相机左侧范围大小
    //public float moveSpeed;//人物到达边框后相机跟随速度
    public GameObject player;

    public float smoothTime = 5f;  //Smooth Time
    private Vector2 velocity = new Vector2(2,2);       //Velocity
                                    // Use this for initialization
    void Start () {

    }

    void Update()
    {
        if (transform.position.x - player.transform.position.x <= rightDis)
        {
            this.transform.position =
            new Vector3(Mathf.SmoothDamp(transform.position.x, player.transform.position.x + xOffest, ref velocity.x, smoothTime), Mathf.SmoothDamp(transform.position.y, player.transform.position.y + yOffest, ref velocity.y, smoothTime), transform.position.z);
            // this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);

        }
        else if (transform.position.x - player.transform.position.x >= leftDis)
        {
            this.transform.position =
            new Vector3(Mathf.SmoothDamp(transform.position.x, player.transform.position.x + xOffest, ref velocity.x, smoothTime), Mathf.SmoothDamp(transform.position.y, player.transform.position.y + yOffest, ref velocity.y, smoothTime), transform.position.z);

            // this.transform.position = new Vector3(this.transform.position.x - moveSpeed, player.transform.position.y, this.transform.position.z);
        }
        else {
            this.transform.position = new Vector3(player.transform.position.x + xOffest, player.transform.position.y + yOffest, this.transform.position.z);

        }
    }
}