
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public GameObject asteroidPrefab,Meteor_miniPrefab;

    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xlimit;
    private float spawnNext = 0;
    public float maxTimeLife = 4f;
    public static int nMax = 0;
    

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext){
            spawnNext = Time.time + 60/spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(-xlimit, xlimit);

            Vector2 spawnPosition = new Vector2(rand, 4f);

            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            Destroy(meteor, maxTimeLife);
        }
    }

}

