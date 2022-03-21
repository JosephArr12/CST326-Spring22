using UnityEngine;
using System.Collections.Generic;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death

    // NOTE! This code should work for any speed value (large or small)

    public List<Transform> waypoints;
    public int health =3;
    public int coins;
    public int nextWaypoint;
    public float speed=3f;
    public int before=0;
    Vector3 beforeVector;

    // public delegate void EnemyDied(EnemyDemo deadEnemy);
    // public event EnemyDied OnEnemyDied;

    //-----------------------------------------------------------------------------
    void Start()
    {
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint")){
           waypoints.Add(waypoint.GetComponent<Transform>());    
        }
        // todo #2
        //   Place our enemy at the starting waypoint
        transform.position = waypoints[0].position;
        nextWaypoint=1;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // // todo #3 Move towards the next waypoint
        // // todo #4 Check if destination reaches or passed and change target
        if(nextWaypoint==waypoints.Count){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
            foreach (GameObject en in enemies){
                Destroy(en,7.0f);
            }
            GameObject.Find("Main Camera").GetComponent<Manager>().GameLost();
        }

        if(nextWaypoint<waypoints.Count){
            Vector3 targetPosition= waypoints[nextWaypoint].position;
            Vector3 movementDirection = (targetPosition - transform.position).normalized;

            transform.LookAt(targetPosition);

            if(before==0){
                beforeVector = (targetPosition - transform.position).normalized;
                before++;
            }
            Vector3 newPosition = transform.position;

            if(Vector3.Dot(movementDirection,beforeVector)<0){
                nextWaypoint++;
                before=0;
            }
            newPosition+=movementDirection*speed*Time.deltaTime;
            transform.position=newPosition;
        }
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
    }

    public void decrementHealth()
    {
      health--;
      if(health<=0){

        GameObject.Find("Main Camera").GetComponent<Manager>().EnemyKilled();
        Destroy(this.gameObject);
      }
    }

}