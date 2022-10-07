using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 1.0f;

    private float spawnRateTimer = 0.0f;


    public GameObject enemyPrefab;

    public List<Transform> spawnPositions;

    public Transform spawnPoint;


    private void CreateEnemyAtRandomSpawnPosition()
    {
        var randomIndex = Random.Range(0, spawnPositions.Count); //Range between 0 to the positions I've put out

        var spawnPoint = spawnPositions[randomIndex]; //gets first position of the list

        var enemyInstance = Instantiate(enemyPrefab);
        enemyInstance.transform.position = spawnPoint.position;
    }


    void Update()
    {
        //Timer code
        if (spawnRateTimer > 0.0f) // 1 > 0? 
        {
            spawnRateTimer -= Time.deltaTime; // 1 - 0.02
            return;
        }

        spawnRateTimer = spawnRate;

        //Exhausted timer behavior
        CreateEnemyAtRandomSpawnPosition();
    }
}
