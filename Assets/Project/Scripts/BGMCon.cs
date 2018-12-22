using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCon : MonoBehaviour {
    public GameObject player;
    public AudioClip bgm1;
    public AudioClip bgm2;
    public AudioClip bgm3;
    private AudioSource bgmController;
    private float spendTime;
    private bool canPlayBGM1;
    private bool canPlayBGM2;
    private bool canPlayBGM3;

    // Use this for initialization
    void Start () {
        bgmController = this.GetComponent<AudioSource>();
        canPlayBGM1 = true;
        canPlayBGM3 = true;
        canPlayBGM2 = true;

    }
	
	// Update is called once per frame
	void Update () {
        spendTime += Time.deltaTime;
        //Debug.Log(bgmController.isPlaying);
        if (spendTime > 5 && (player.transform.position.x < 45|| player.transform.position.x>495))
        {
            if (bgmController.clip == bgm2 || bgmController.clip == bgm3)
                bgmController.Stop();
            if (canPlayBGM1 == true)
            {
                bgmController.clip = bgm1;
                bgmController.Play();
                canPlayBGM1 = false;
            }
        }
        if(player.transform.position.x>45&& player.transform.position.x <343)
        {
            if(bgmController.clip==bgm1|| bgmController.clip == bgm3)
                bgmController.Stop();
            if(canPlayBGM2==true)
            {
                bgmController.clip = bgm2;
                bgmController.Play();
                canPlayBGM2 = false;
            }
        }
        if (player.transform.position.x > 343&& player.transform.position.x<495)
        {
            if (bgmController.clip == bgm1 || bgmController.clip == bgm2)
                bgmController.Stop();
            if (canPlayBGM3 == true)
            {
                bgmController.clip = bgm3;
                bgmController.Play();
                canPlayBGM3 = false;
            }
        }


        if (bgmController.isPlaying==false)
        {
            canPlayBGM1 = true;
            canPlayBGM2 = true;
            canPlayBGM3 = true;
        }

	}
}
