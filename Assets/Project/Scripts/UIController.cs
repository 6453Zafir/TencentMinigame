using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject EnsureButton,WindButton,FireButton;
    private Material InkMelt;
    public GameObject MiddleInklast;

    public Sprite blackInkTexture, RedInkTexture, BlueInkTexture,blackFishTexture,blueFishTexture,redFishTexture;


    /// <summary>
    /// 0:black, 1:blue, 2:red
    /// </summary>
    public static int CurrentBrushColor = 0;

    private Color redColor = new Color(0.74f,0.39f,0.39f), 
                  blueColor = new Color(0.74f, 0.39f, 0.39f), 
                  blackColor = new Color(0,0,0);
	// Use this for initialization
	void Start () {
        InkMelt = MiddleInklast.GetComponent<Image>().material;
        WindButton.SetActive(false);
        FireButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
       
        InkMelt.SetFloat("_Threshold",  Mathf.Sin(Time.time * 0.3f));
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


}
