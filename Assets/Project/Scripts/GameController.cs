using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static int checkPoint = 0;
    public static int LevelNum = 0;
    public static int InkNum = 0;
    public static int TotalInk = 30;
    public GameObject canvas;
    public GameObject endVideo;
    public static float maxPlayerX = -52;
    private bool endVideoPlayed = false;

    public static bool isWindGet = false, isFireGet = false;
    private bool isWindGetSet = false, isFireGetSet = false;

    public static bool isInPaintMode = false;
    public static float InkDistance = 20.0f;
    public static float InkTotalDistance = 20.0f;
    //黑色画笔控制
    public static int BlackLine_numzero = 0;
    public static int BlackLine_num = 0;
    //红色画笔控制
    public static int RedLine_numzero = 0;
    public static int RedLine_num = 0;
    public static int Fire_num = 0;
    public static int Fire_numzero = 0;
    //蓝色画笔控制
    public static int BlueLine_numzero = 0;
    public static int BlueLine_num = 0;

    //风力控制
    public static bool forceReady = false;//是否加过风力了
    public static bool forceOnBoatReady = false;//是否给船加过风力了
    public static float windforce = 40.0f;
    public static float forceDuration = 1.0f;//力的持续时间
    public static bool wind_count = false;//风力开始生效，开始计时

    private UIController UICon;
    private GameObject Player;
    float duration = 2.0f;
    private void Awake()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        UICon = GameObject.Find("Canvas").gameObject.GetComponent<UIController>();
    }

    // Use this for initialization
    void Start () {
        canvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > 6 && !canvas.activeInHierarchy&& maxPlayerX < 500f)
        {
            canvas.SetActive(true);
        }
        if (Player.transform.position.x > maxPlayerX) {
            maxPlayerX = Player.transform.position.x;
        }
        if (Player.transform.position.x > 161f &&!isWindGetSet) {
            //获得风之力,调色板加颜色，放字幕
            UICon.showUIButton(1);
            isWindGet = true;
            isWindGetSet = true;
        }
        if (Player.transform.position.x > 345.7f && !isFireGetSet) {
            //获得火之力,调色板加颜色，放字幕
            UICon.showUIButton(2);
            isFireGet = true;
            isFireGetSet = true;
        }
        if (Time.time > 6&& GameObject.Find("BeginVideo")!=null) {
            
            GameObject.Find("BeginVideo").gameObject.SetActive(false);
        }
        if (maxPlayerX > 501&&!endVideoPlayed) {
            canvas.SetActive(false);
            endVideo.SetActive(true);
            endVideoPlayed = true;
        }
	}
}