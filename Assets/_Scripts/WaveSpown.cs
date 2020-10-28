using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveSpown : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public GameObject flyingEnemyPrefab;
    public Transform spawnPoint;
    public Transform spawnPointBoss;
    public Transform spawnPointFlying;
    public Transform EnemySpown;
    public float TimeSpown = 5f;
    private float Countdown = 2f;
    public float TimeSpownFlying = 8f;
    private float CountdownFlying = 4f;
    public float TimeSpownBoss = 2f;
    private float CountdownBoss = 20f;
    void Update()
    {
        if (Countdown <= 0f)
        {
            SpawnEnemy();
            Countdown = TimeSpown;
            //SpawnEnemyFlying();
            //CountdownFlying = TimeSpownFlying;
            //SpawnBoss();
            //CountdownBoss = TimeSpownBoss;  
        }
        Countdown -= Time.deltaTime;

        if (CountdownFlying <= 0f)
        {
            SpawnEnemyFlying();
            CountdownFlying = TimeSpownFlying;
             
        }
        CountdownFlying -= Time.deltaTime;
        if (CountdownBoss <= 0f)
        {
            SpawnBoss();
            CountdownBoss = TimeSpownBoss;  
        }
        
        CountdownBoss -= Time.deltaTime;

    }


    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.transform.SetParent(EnemySpown);
        
    }

    void SpawnBoss()
    {
        GameObject enemy1 = Instantiate(bossPrefab, spawnPointBoss.position, spawnPointBoss.rotation);
        enemy1.transform.SetParent(EnemySpown);

    }

    void SpawnEnemyFlying()
    {
        GameObject enemy2 = Instantiate(flyingEnemyPrefab, spawnPointFlying.position, spawnPointFlying.rotation);
        enemy2.GetComponent<Enemy>().SetFlyingWaypoints();
        enemy2.transform.SetParent(EnemySpown);

    }


}

