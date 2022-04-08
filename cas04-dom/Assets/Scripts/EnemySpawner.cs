using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> spawnedEnemies;
    public GameObject enemyPrefab;
    public List<Vector3> spawnPoints;
    public int numberOfEnemies;
    private int enemyCount;
    public int spawnTime;
    private Coroutine spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(SpawnCoroutine(spawnTime));
    }

    private void Awake() {
        spawnedEnemies = new List<GameObject>();
        spawnPoints = new List<Vector3>();
        spawnPoints.Add(new Vector3(-10f,0f,-25f));
        spawnPoints.Add(new Vector3(10f,0f,-25f));
        enemyCount = 0;
    }

    public IEnumerator SpawnCoroutine(int timeForSpawn)
    {
        System.Random randomIndex = new System.Random();

        while (true) {

            int index = randomIndex.Next(0, spawnPoints.Count);
            Vector3 spawnPosition = spawnPoints[index];

            GameObject instantiatedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            instantiatedEnemy.GetComponent<Enemy>().SetId(enemyCount);
            spawnedEnemies.Add(instantiatedEnemy);
            enemyCount++;

            if(enemyCount >= numberOfEnemies)
            {
                yield break;
            }
            
            yield return new WaitForSecondsRealtime(timeForSpawn);

        }
    }
}
