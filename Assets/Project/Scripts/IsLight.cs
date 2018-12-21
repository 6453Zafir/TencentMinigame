using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLight : MonoBehaviour {
    public GameObject myPrefab;
    private bool Islight = false;
    private bool ready = false;
    private Vector3 missing = new Vector3(27.88f, 2.96f, 0);
    // Use this for initialization
    void Start () {
        ready = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Islight)
        {
            GameObject newObject = Instantiate(myPrefab) as GameObject;
            newObject.transform.position = this.gameObject.GetComponent<Transform>().position + missing;
            newObject.transform.name = "FireWithLight";
            Islight = false;
        }
      
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(!ready)
        {
            Islight = true;
            ready = true;
        }
       
    }
}
