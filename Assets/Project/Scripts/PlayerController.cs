using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rig;
    public float speed;
    private int face;//记录朝向
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        speed = 3.6f;
        face = 1;//开始向右
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector2(-speed,rig.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2(speed, rig.velocity.y);
        }
        if (rig.velocity.x < 0)
            this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x,180,this.transform.localEulerAngles.z);
        else if (rig.velocity.x > 0)
            this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x,0, this.transform.localEulerAngles.z);
    }
}
