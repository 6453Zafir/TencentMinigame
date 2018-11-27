using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject MenuButton;
    public GameObject ElementPanel;
    public Text Ink;
    public Text Level;
    public GameObject DrawLine;


    public LineRenderer WoodMat;
    public LineRenderer StoneMat;
    public LineRenderer WindMat;
    public LineRenderer WaterMat;
    public LineRenderer FireMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        setText(Ink,GameController.InkNum.ToString());
        setText(Level, GameController.LevelNum.ToString());

	}


    public void ToggelActiveList(){
        ElementPanel.SetActive(!ElementPanel.activeInHierarchy);
        if(ElementPanel.activeInHierarchy){
            MenuButton.SetActive(false);
        }else{
            MenuButton.SetActive(true);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ToolNum">Tool number. 0:Wood  1:Stone  2:Wind  3:Water  4: Fire</param>
    public void ModifyTool(int ToolNum)
    {
        switch (ToolNum)
        {
            case 0:
                GameController.CurrentTool = 0;
                DrawLine.GetComponent<DrawLine2D>().lineRenderer = WoodMat;
                break;
            case 1:
                GameController.CurrentTool = 1;
                DrawLine.GetComponent<DrawLine2D>().lineRenderer = StoneMat;
                break;
            case 2:
                GameController.CurrentTool = 2;
                DrawLine.GetComponent<DrawLine2D>().lineRenderer = WindMat;
                break;
            case 3:
                GameController.CurrentTool = 3;
                DrawLine.GetComponent<DrawLine2D>().lineRenderer = WaterMat;
                break;
            case 4: 
                GameController.CurrentTool = 4;
                DrawLine.GetComponent<DrawLine2D>().lineRenderer = FireMat;

                break;
            default:break;
        }
        ToggelActiveList();
    }



    public void setText( Text textToSet, string text){
        textToSet.text = text;
    }

}
