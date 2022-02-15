using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{
    public bool isP1Goal;
    private void OnTriggerExit(Collider other)
    {

        GameObject.Find("Ball").GetComponent<Ball>().trail.Clear();

        if (other.gameObject.CompareTag("Ball"))
        {
            if (isP1Goal)
            {
                Debug.Log("Player 2 (Right) Scored");

                GameObject.Find("Ball").GetComponent<Ball>().scoredDirection = -1;

                GameObject.Find("Ball").GetComponent<Ball>().Reset();

                GameObject.Find("Manager").GetComponent<Manager>().P2Score ++;

                GameObject.Find("Manager").GetComponent<Manager>().ScoreKeeper();

            }
            else
            {
                Debug.Log("Player 1 (Left) Scored");
                GameObject.Find("Ball").GetComponent<Ball>().scoredDirection = 1;
                GameObject.Find("Ball").GetComponent<Ball>().Reset();
                GameObject.Find("Manager").GetComponent<Manager>().P1Score++;
                GameObject.Find("Manager").GetComponent<Manager>().ScoreKeeper();
            }
        }
    }

}
