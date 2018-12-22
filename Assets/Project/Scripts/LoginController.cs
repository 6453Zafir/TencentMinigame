using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour {
    public GameObject panel1, panel2, tempButton, hasAccountButton, loginbutton, backbutton;
	// Use this for initialization
	void Start () {
        panel1.SetActive(true);
        panel2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TempEnter() {
        this.gameObject.SetActive(false);
    }
    public void Login() {

        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    public void Back() {
        panel1.SetActive(true);
        panel2.SetActive(false);
    }
}
