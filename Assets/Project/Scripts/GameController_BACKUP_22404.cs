using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static int LevelNum = 0;
    public static int checkPoint = 0;
    public static int InkNum = 30;
    public static int TotalInk = 30;
    public static int CurrentTool = 10;
    //黑色画笔控制
    public static float BlackDistance = 30;
    public static float BlackTotalDistance = 30;
    public static int BlackLine_numzero = 0;
    public static int BlackLine_num = 0;
    //红色画笔控制
    public static float RedDistance = 30;
    public static float RedTotalDistance = 30;
    public static int RedLine_numzero = 0;
    public static int RedLine_num = 0;
    public static int Fire_num = 0;
    public static int Fire_numzero = 0;

<<<<<<< HEAD

    public Material NormalMat, CaveMat;

    private GameObject Player;
    private GameObject[] rollingBGs;
    float duration = 2.0f;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        rollingBGs = GameObject.FindGameObjectsWithTag("RollingBg");
    }

=======
>>>>>>> 1f1d3c9f2d861b95b9edafe6aee1a3b1c4d5ab70
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //if (Player.transform.position.x > 340f){
            foreach (GameObject bg in rollingBGs) {
                float lerp = Mathf.PingPong(Time.time, duration) / duration;
                if (bg.GetComponent<SpriteRenderer>() != null) {
                    print(bg.name);

                }
           // }
        }
	}
}
