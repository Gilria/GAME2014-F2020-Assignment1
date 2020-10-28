using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float health;

    public GameObject coin;
    private Transform coinPool;

    private Transform target;


    private GameObject PathFinder;

    private int wavepointIndex = 0;
    private int currentEnemyType;//0=walking, 1=flying

    private AudioSource audioSource;
    



    void Awake()
    {
        coinPool = GameObject.FindGameObjectWithTag("CoinPool").transform;
        PathFinder = GameObject.FindGameObjectWithTag("WayPointsLand");
        target = PathFinder.GetComponent<Waypoints>().waypoints[0] ;
    }

    void Start()
    {

    }



    private void Update()
    {
        if (transform.parent != null)
        {
            audioSource = transform.parent.GetComponent<AudioSource>();
        }

        SetNewPathFinder();
        DieCheck();

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position)<= 10f)
        {
            GetNextWaypoint();
        }

        void GetNextWaypoint()
        {
            if (wavepointIndex >= PathFinder.GetComponent<Waypoints>().waypoints.Length - 1)//enemy arrived the final point
            {
                BuildController.numOfLives--;
                Destroy(gameObject);
                return;
            }
            
            wavepointIndex++;
            target = PathFinder.GetComponent<Waypoints>().waypoints[wavepointIndex];
        }
    }

    public void SetFlyingWaypoints()
    {
        currentEnemyType = 1;
    }

    void SetNewPathFinder()
    {
        if (currentEnemyType==1)
        {
            PathFinder = GameObject.FindGameObjectWithTag("WayPointsFly");
            //target = PathFinder.GetComponent<Waypoints>().waypoints[0];
        }
    }

    void DieCheck()
    {
        if (health<=0)
        {
            int randomNum = Random.Range(0,9);
            if (randomNum==0)
            {
                //GameObject coinDrop = Instantiate(coin, transform.position, Quaternion.identity, coinPool);
                for (int i = 0; i < coinPool.childCount; i++)
                {
                    if (!coinPool.GetChild(i).gameObject.activeInHierarchy){
                        GameObject coinDrop = coinPool.GetChild(i).gameObject;
                        coinDrop.transform.position = transform.position;
                        coinDrop.SetActive(true);
                        break;
                    }
                }
            }
            audioSource.Play();
            BuildController.goldLeft += 5;
            BuildController.numOfKills+=1;
            Destroy(gameObject);
        }
    }

}
