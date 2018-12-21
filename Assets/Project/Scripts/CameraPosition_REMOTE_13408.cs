using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    public float areaDis;//相机范围大小
    public float startPositionX;//相机初始位置
    public float moveSpeed;//人物到达边框后相机跟随速度  0.06还算平滑
    public float xPosition;//相机x轴目标位置
    public float yPosition;//相机y轴目标位置
    public float zPosition;//相机z轴目标位置

    public GameObject player;
	// Use this for initialization
	void Start () {
        //初始化相机位置
        //this.transform.position = new Vector3(this.transform.position.x+startPositionX,this.transform.position.y,this.transform.position.z);

        xPosition = this.transform.position.x;
        yPosition = this.transform.position.y;
        zPosition = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    private void FixedUpdate()
    {
        //Debug.Log(player.transform.position.x);
 
        xPosition = this.transform.position.x;
        yPosition = this.transform.position.y;
        zPosition = this.transform.position.z;
        if(player.transform.position.x-this.transform.position.x>10|| player.transform.position.x - this.transform.position.x<-10)
        {
            this.transform.position =new Vector3 (player.transform.position.x + 4.3f, player.transform.position.y, player.transform.position.z);
        }
        if (player.transform.localPosition.x < 175f)
        {
            yPosition = player.transform.position.y+3.6f;
            zPosition = player.transform.position.z-10;
            if (player.transform.position.x - this.transform.position.x + startPositionX > areaDis || player.transform.position.x - this.transform.position.x + startPositionX < -areaDis)
            {
                xPosition = player.transform.position.x + startPositionX;
                //this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);
            }
            MoveCameraTo(xPosition, yPosition, zPosition);
        }
        //走到落石关
        else if (player.transform.localPosition.x>173f&&player.transform.localPosition.x<190f)
        {
            if (player.transform.localPosition.y > -5)
            {
                yPosition = player.transform.position.y - 6;
                zPosition = player.transform.position.y - 13;
                if (player.transform.position.x - this.transform.position.x + startPositionX > areaDis || player.transform.position.x - this.transform.position.x + startPositionX < -areaDis)
                {
                    xPosition = player.transform.position.x + startPositionX;
                    //this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);
                }
            }
            else
            {
                yPosition = player.transform.position.y;
                zPosition = player.transform.position.z - 10;
                if (player.transform.position.x - this.transform.position.x + startPositionX > areaDis || player.transform.position.x - this.transform.position.x + startPositionX < -areaDis)
                {
                    xPosition = player.transform.position.x + startPositionX;
                    //this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);
                }
                MoveCameraTo(xPosition, yPosition, zPosition);
            }
            MoveCameraTo(xPosition, yPosition, zPosition);
        }
        //通过落石关
        else if(player.transform.localPosition.x>190f&&player.transform.localPosition.x<205f)
        {
            
            yPosition = player.transform.position.y+3.4f;
            zPosition = player.transform.position.z-12f;
            if (player.transform.position.x - this.transform.position.x + startPositionX > areaDis || player.transform.position.x - this.transform.position.x + startPositionX < -areaDis)
            {
                xPosition = player.transform.position.x + startPositionX;
                //this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);
            }
            MoveCameraTo(xPosition, yPosition, zPosition);
        }

        else if (player.transform.localPosition.x > 205f && player.transform.localPosition.x < 255f)
        {

            yPosition = player.transform.position.y + 3.9f;
            zPosition = player.transform.position.z - 12f;
            if (player.transform.position.x - this.transform.position.x + startPositionX > areaDis || player.transform.position.x - this.transform.position.x + startPositionX < -areaDis)
            {
                xPosition = player.transform.position.x + startPositionX;
                //this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);
            }
            MoveCameraTo(xPosition, yPosition, zPosition);
        }
        //中间关卡，有些不太了解，靠瞬移过关，还有待修改
        else if (player.transform.localPosition.x > 255f && player.transform.localPosition.x < 500f)
        {

            yPosition = player.transform.position.y + 3.9f;
            zPosition = player.transform.position.z - 12f;
            if (player.transform.position.x - this.transform.position.x + startPositionX > areaDis || player.transform.position.x - this.transform.position.x + startPositionX < -areaDis)
            {
                xPosition = player.transform.position.x + startPositionX;
                //this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);
            }
            MoveCameraTo(xPosition, yPosition, zPosition);
        }
        //最后火烧绳巨石关
        else if (player.transform.localPosition.x > 500f )
        {

            yPosition = player.transform.position.y + 6f;
            zPosition = player.transform.position.z - 17f;
            if (player.transform.position.x - this.transform.position.x + startPositionX > areaDis || player.transform.position.x - this.transform.position.x + startPositionX < -areaDis)
            {
                xPosition = player.transform.position.x + startPositionX;
                //this.transform.position = new Vector3(this.transform.position.x + moveSpeed, player.transform.position.y, this.transform.position.z);
            }
            MoveCameraTo(xPosition, yPosition, zPosition);
        }

    }


    //移动相机到某个位置，可以通过改变值0.05来改变相机判定每帧是否移动，可防止鬼畜现象，并且更加平滑
    private void MoveCameraTo(float targetx,float targety,float targetz)
    {
        //移动x
        if (targetx - this.transform.position.x >0.05)
        {
            this.transform.position = new Vector3(this.transform.position.x + moveSpeed, this.transform.position.y, this.transform.position.z);
        }
        else if(targetx - this.transform.position.x < -0.05)
        {
            this.transform.position = new Vector3(this.transform.position.x - moveSpeed, this.transform.position.y, this.transform.position.z);
        }
        //移动y
        if (targety - this.transform.position.y > 0.05)
        {
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y + moveSpeed, this.transform.position.z);
        }
        else if (targety - this.transform.position.y < -0.05)
        {
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y - moveSpeed, this.transform.position.z);
        }
        //移动z
        if (targetz - this.transform.position.z > 0.05)
        {
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z + moveSpeed);
        }
        else if (targetz - this.transform.position.z <- 0.05)
        {
            this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z - moveSpeed);
        }
    }
}