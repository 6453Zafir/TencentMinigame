using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static int LevelNum = 0;
    public static int checkPoint = 0;
    public static int InkNum = 30;
    public static int TotalInk = 30;
    public static int CurrentTool = 10;


    public Material NormalMat, CaveMat;

    private GameObject Player;
    private GameObject[] rollingBGs;
    float duration = 2.0f;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        rollingBGs = GameObject.FindGameObjectsWithTag("RollingBg");
    }

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
