using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private GameObject PathFinder;


    void Start()
    {
        PathFinder = GameObject.FindGameObjectWithTag("WayPointsLand");
        target = PathFinder.GetComponent<Waypoints>().waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        void GetNextWaypoint()
        {
            if (wavepointIndex >= PathFinder.GetComponent<Waypoints>().waypoints.Length - 1)
            {
                
                    Destroy(gameObject);
                
               
                return;
            }

            wavepointIndex++;
            target = PathFinder.GetComponent<Waypoints>().waypoints[wavepointIndex];
        }
    }
}
