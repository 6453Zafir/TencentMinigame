using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour {



    public GameObject threepoint;
    public GameObject threetext;

    public GameObject fourpoint;
    public GameObject fourtext;
   

    public GameObject fivepoint;
    public GameObject fivetext;
   

    public GameObject sixpoint;
    public GameObject sixtext;


    public GameObject sevenpoint;
    public GameObject seventext;
  

    public GameObject eightpoint;
    public GameObject eighttext;


    public GameObject ninepoint;
    public GameObject ninetext;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float dis3 = (threepoint.transform.position - this.transform.position).sqrMagnitude;
        if(dis3<1)
        {
            threetext.SetActive(true);
        }

        float dis4= (fourpoint.transform.position - this.transform.position).sqrMagnitude;
        if (dis4 < 1)
        {
            fourtext.SetActive(true);
      
        }

        float dis5 = (fivepoint.transform.position - this.transform.position).sqrMagnitude;
        if (dis5 < 1)
        {
            fivetext.SetActive(true);
           
        }

        float dis6 = (sixpoint.transform.position - this.transform.position).sqrMagnitude;
        if (dis6 < 1)
        {
            sixtext.SetActive(true);
           
        }


        float dis7 = (sevenpoint.transform.position - this.transform.position).sqrMagnitude;
        if (dis7 < 1)
        {
            seventext.SetActive(true);
            
        }

        float dis8 = (eightpoint.transform.position - this.transform.position).sqrMagnitude;
        if (dis8 < 1)
        {
            eighttext.SetActive(true);
       
        }

        float dis9 = (ninepoint.transform.position - this.transform.position).sqrMagnitude;
        if (dis9 < 1)
        {
            ninetext.SetActive(true);
         
        }

    }
}
