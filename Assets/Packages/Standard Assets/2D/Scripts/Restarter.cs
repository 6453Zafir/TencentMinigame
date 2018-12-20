using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private GameObject player;
        public void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                player.transform.position = GetNewestCheckPoint();
               // SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
        }

        public Vector3 GetNewestCheckPoint()
        {
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
                        if (player.transform.position.x > 197)
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


}
