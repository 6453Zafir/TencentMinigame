using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject EnsureButton,WindButton,FireButton,DeadInk,DeadText, HideDeadUIBtn;
    private Material InkMelt;
    private bool isDeadUIShowing = false;
    private Text currentShowingText;
    public GameObject MiddleInklast;
    GameObject player;

    public Sprite blackInkTexture, RedInkTexture, BlueInkTexture,blackFishTexture,blueFishTexture,redFishTexture;


    /// <summary>
    /// 0:black, 1:blue, 2:red
    /// </summary>
    public static int CurrentBrushColor = 0;

    private Color redColor = new Color(0.74f,0.39f,0.39f), 
                  blueColor = new Color(0.74f, 0.39f, 0.39f), 
                  blackColor = new Color(0,0,0),
                  transColor = new Color(0,0,0,0),
                  whiteColor = new Color(1, 1, 1, 1);
    // Use this for initialization
    void Start () {
        InkMelt = MiddleInklast.GetComponent<Image>().material;
        WindButton.SetActive(false);
        FireButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        print("当前余墨：" + GameController.InkDistance);
        InkMelt.SetFloat("_Threshold", 1- GameController.InkDistance / GameController.InkTotalDistance);

        if (PlayerController.DeadType ==1|| PlayerController.DeadType == 2)
        {
            if (!isDeadUIShowing)
            {
                DeadInk.GetComponent<Animator>().SetBool("isDead", true);
                currentShowingText = getDeadTextFromPlayerState();
                StartCoroutine(showText(currentShowingText, 10f));
                StartCoroutine(EnDisableRestartButton(true, 0.5f));
            }
            else
            {
                DeadInk.GetComponent<Animator>().SetBool("isDead", false);
                StartCoroutine(EnDisableRestartButton(false, 0.1f));
                player = GameObject.FindGameObjectWithTag("Player").gameObject;
                player.transform.position = GetNewestCheckPoint();
                currentShowingText.color = transColor;
            }
        }
        if (PlayerController.DeadType == 3)
        {
            if (!isDeadUIShowing)
            {
                DeadInk.GetComponent<Animator>().SetBool("isDead", true);
                currentShowingText = getDeadTextFromPlayerState();
                StartCoroutine(showText(currentShowingText, 10f));
                StartCoroutine(EnDisableRestartButton(true, 0.5f));
            }
            else
            {
                DeadInk.GetComponent<Animator>().SetBool("isDead", false);
                StartCoroutine(EnDisableRestartButton(false, 0.1f));
                currentShowingText.color = transColor;
            }
        }
    }


    public void InkButton(GameObject ob) {

            switch (CurrentBrushColor)
            {
                case 0:
                    ob.GetComponent<Image>().sprite = blackFishTexture;
                    break;
                case 1:
                    ob.GetComponent<Image>().sprite = blueFishTexture;
                    break;
                case 2:
                    ob.GetComponent<Image>().sprite = redFishTexture;
                    break;
                default:
                    break;
            }


            switch (ob.GetComponent<InkButton>().ColorNum)
            {
                case 0:
                    MiddleInklast.GetComponent<Image>().sprite = blackInkTexture;
                    break;
                case 1:
                    MiddleInklast.GetComponent<Image>().sprite = BlueInkTexture;
                    break;
                case 2:
                    MiddleInklast.GetComponent<Image>().sprite = RedInkTexture;
                    break;
                default:
                    break;
            }
            int temp = ob.GetComponent<InkButton>().ColorNum;
            ob.GetComponent<InkButton>().ColorNum = CurrentBrushColor;
            CurrentBrushColor = temp;
            GameController.isInPaintMode = true;
            startDraw();
    }
    public void ReCycle()
    {
        if (GameController.isInPaintMode)
        {
            /// 回收墨水
            Debug.Log("ink recycled");
            print("ink recycled");
        }
        else {
            startDraw();
            GameController.isInPaintMode = true;
        }
    }
    public void EnsurePainting() {
        GameController.isInPaintMode = false;
        endDraw();
    }

    private void startDraw() {
        ///在此激活画笔工具
        ///显示确认按钮
        ///禁用人物控制
        EnsureButton.SetActive(true);
        Debug.Log("start draw");
    }
    private void endDraw()
    {
        ///在此禁用画笔工具
        ///开启人物控制
        ///隐藏确认作画按钮
        Debug.Log("end draw");

        EnsureButton.SetActive(false);
    }

    public void setText( Text textToSet, string text){
        textToSet.text = text;
    }

    public void showUIButton(int inkNum) {
        if (inkNum == 1)
        {
            WindButton.SetActive(true);
        }
        else if (inkNum ==2) {
            FireButton.SetActive(true);
        }
        else {
            print("UI show button has wrong input parameter");
        }
    }

    IEnumerator EnDisableRestartButton(bool isEnable,float waitime) {
        yield return new WaitForSeconds(waitime);
        HideDeadUIBtn.SetActive(isEnable);
    }


    public void HideDeadUI() {
        isDeadUIShowing = true;
       StartCoroutine(Changestate(1.5f));
    }

    IEnumerator Changestate(float waitime)
    {
        yield return new WaitForSeconds(waitime);
        isDeadUIShowing = false;
        PlayerController.DeadType = 0;
    }

    private Text getDeadTextFromPlayerState() {
        if (PlayerController.DeadType == 1)
        {
            DeadText.transform.GetChild(0).gameObject.SetActive(true);
            DeadText.transform.GetChild(1).gameObject.SetActive(false);
            DeadText.transform.GetChild(2).gameObject.SetActive(false);
            return DeadText.transform.GetChild(0).gameObject.GetComponent<Text>();
        }
        else if (PlayerController.DeadType == 2)
        {
            DeadText.transform.GetChild(0).gameObject.SetActive(false);
            DeadText.transform.GetChild(1).gameObject.SetActive(true);
            DeadText.transform.GetChild(2).gameObject.SetActive(false);
            return DeadText.transform.GetChild(1).gameObject.GetComponent<Text>();
        }
        else if (PlayerController.DeadType == 3)
        {
            DeadText.transform.GetChild(0).gameObject.SetActive(false);
            DeadText.transform.GetChild(1).gameObject.SetActive(false);
            DeadText.transform.GetChild(2).gameObject.SetActive(true);
            return DeadText.transform.GetChild(2).gameObject.GetComponent<Text>();
        }
        else {
            return null;
        }
    }

    IEnumerator showText(Text txt, float fadeSpeed)
    {

        while (txt.color.a <= 1)
        {
            txt.color = Color.Lerp(txt.color, whiteColor, fadeSpeed * Time.deltaTime);
            break;
        }
        yield return null;
    }


    public Vector3 GetNewestCheckPoint()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Vector3 pos = Vector3.zero;
        switch (GameController.LevelNum)
        {
            case 0:
                {
                    if (player.transform.position.x > 30)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-1").transform.position;
                    }
                    if (player.transform.position.x > 50)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-2").transform.position;
                    }
                    if (player.transform.position.x > 126)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-3").transform.position;
                    }
                    if (player.transform.position.x > 190)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-4").transform.position;
                    }
                    if (player.transform.position.x > 224)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-5").transform.position;
                    }
                    if (player.transform.position.x > 277)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-6").transform.position;
                    }
                    if (player.transform.position.x > 322)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-7").transform.position;
                    }
                    if (player.transform.position.x > 415)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-8").transform.position;
                    }
                    if (player.transform.position.x > 462)
                    {
                        pos = GameObject.Find("/CheckPoints/CP1-9").transform.position;
                    }
                    break;
                }
            case 1:
                pos = Vector3.zero;
                break;
            case 2:
                pos = Vector3.zero;
                break;
            case 3:
                pos = Vector3.zero;
                break;
            case 4:
                pos = Vector3.zero;
                break;
            default:
                pos = Vector3.zero;
                break;
        }

        return pos;
    }

}
