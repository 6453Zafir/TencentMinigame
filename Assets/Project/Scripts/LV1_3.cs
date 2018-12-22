using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1_3 : MonoBehaviour {
    public float RookCDTime = 3;

    private Transform rockPos;
    private GameObject Obstacle;
    private GameObject Target;
    private GameObject Player;
    private GameObject RockPrefab;
    private GameObject currentRock;

    private bool ShouldNewRock = true;
    private bool isPass = false;
    private bool isResourceLoad = false;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > 110)
        {
            if (!isResourceLoad)
            {
                RockPrefab = Resources.Load("RollingRock") as GameObject;
                rockPos = transform.Find("RockStartPos").transform;
                Obstacle = transform.Find("Obstacle").gameObject;
                Target = transform.Find("Target").gameObject;
                isResourceLoad = true;
            }
            if (!isPass)
            {

                if (isResourceLoad && ShouldNewRock)
                {
                    currentRock = Instantiate(RockPrefab, rockPos);
                    currentRock.transform.SetParent(rockPos);
                    currentRock.transform.localPosition = Vector3.zero;
                    ShouldNewRock = false;
                }
            }
            if (currentRock != null)
            {
                if (currentRock.transform.localPosition.y < -21.37f)
                {
                    ShouldNewRock = true;
                    Destroy(currentRock);
                }
            }
            //    if (isResourceLoad && ShouldNewRock)
            //    {
            //    currentRock = Instantiate(RockPrefab, rockPos);
            //    currentRock.transform.SetParent(rockPos);
            //    currentRock.transform.localPosition = Vector3.zero;
            //    StartCoroutine(CreatRockWithCD(currentRock));
            //}
            if (Vector3.Distance(currentRock.transform.position, Target.transform.position) < 2.7f)
            {
                StartCoroutine(PassAnimation(1));
                isPass = true;
            }
        }
    }

    //IEnumerator CreatRockWithCD(GameObject currentRock) {
    //    ShouldNewRock = false;
    //    yield return new WaitForSeconds(RookCDTime);
    //    Destroy(currentRock);
    //    ShouldNewRock = true;
    //}

    IEnumerator PassAnimation(float ObsatcleWaitTime) {
        Target.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(ObsatcleWaitTime);
        Obstacle.GetComponent<Animation>().Play();
  
}

}
