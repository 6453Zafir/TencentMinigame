using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2_1 : MonoBehaviour {
    private GameObject Player;
    private Transform FlowerPos;

    private bool hasParticle = false;
    private bool FirstCome = true;

    private GameObject FPPrefab;
    private GameObject currentParticle;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > 140 && Player.transform.position.x < 210)
        {
            if (FirstCome)
            {
                FPPrefab = Resources.Load("MainFlowerParticle") as GameObject;
                FlowerPos = transform.Find("MainFlowerPos").transform;
                FirstCome = false;
            }
            if (!hasParticle)
            {
                currentParticle = Instantiate(FPPrefab, FlowerPos);
                currentParticle.transform.SetParent(FlowerPos);
                currentParticle.transform.localPosition = Vector3.zero;
                hasParticle = true;
            }
        }
        else {
            if (hasParticle && currentParticle != null) {
                Destroy(currentParticle);
                hasParticle = false;
            }
        }
    }
}
