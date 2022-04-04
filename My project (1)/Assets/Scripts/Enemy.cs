using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death

    // NOTE! This code should work for any speed value (large or small)

    public List<Transform> waypoints;
    public int health = 4;
    public int coins;
    public int nextWaypoint;
    public float speed=1.5f;
    public int before=0;
    Vector3 beforeVector;
    // public UnityEngine.AI.NavMeshAgent agent;
    public Slider slider;

    // public delegate void EnemyDied(EnemyDemo deadEnemy);
    // public event EnemyDied OnEnemyDied;

    //-----------------------------------------------------------------------------
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
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
                Destroy(en);
            }
            GameObject.Find("Main Camera").GetComponent<Manager>().GameLost();
        }

        if(nextWaypoint<waypoints.Count){
            Vector3 targetPosition= waypoints[nextWaypoint].position;
            Vector3 movementDirection = (targetPosition - transform.position).normalized;

            transform.LookAt(targetPosition);
            //transform.LookAt(waypoints[waypoints.Count-1].position);

            if(before==0){
                beforeVector = (targetPosition - transform.position).normalized;
                before++;
            }
            Vector3 newPosition = transform.position;

            if(Vector3.Dot(movementDirection,beforeVector)<0){
                nextWaypoint++;
                before=0;
            }
            // agent.SetDestination(waypoints[nextWaypoint].position);
            // agent.SetDestination(waypoints[waypoints.Count-1].position);
            newPosition+=movementDirection*speed*Time.deltaTime;
            transform.position=newPosition;
        }
    }

    //-----------------------------------------------------------------------------

    public void decrementHealth()
    {
      health--;
      slider.value=health;
      if(health<=0){

        GameObject.Find("Main Camera").GetComponent<Manager>().EnemyKilled();
        Destroy(this.gameObject);
      }
    }

void OnTriggerEnter(Collider other){
  Debug.Log("hello");
  decrementHealth();
}

}