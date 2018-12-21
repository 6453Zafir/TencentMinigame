using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour
{



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

    public GameObject tenpoint;
    public GameObject tentext1;
    public GameObject tentext2;
    public GameObject tentext3;
    public GameObject tentext4;

    public float interval = 1.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dis3 = (threepoint.transform.position - this.transform.position).sqrMagnitude;
        if (dis3 < 1)
        {
            threetext.SetActive(true);
        }

        float dis4 = (fourpoint.transform.position - this.transform.position).sqrMagnitude;
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

        float dis10 = (tenpoint.transform.position - this.transform.position).sqrMagnitude;
        if (dis10 < 1)
        {
            tentext1.SetActive(true);
            Invoke("show2", interval);


        }

    }

    void show2()
    {
        tentext2.SetActive(true);
        Invoke("show3", interval);
        Debug.Log("show3");
    }
    void show3()
    {
        tentext3.SetActive(true);
        Invoke("show4", interval);
    }

    void show4()
    {
        tentext4.SetActive(true);
    }

}
