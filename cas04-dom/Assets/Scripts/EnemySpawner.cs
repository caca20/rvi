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

    public GameObject SpawnEnemy(){
        System.Random rand = new System.Random();
        int itemIndex = Random.Range (0,(spawnPoints.Count));
        Vector3 pos = spawnPoints[itemIndex];
        GameObject res = Instantiate(enemyPrefab,pos,Quaternion.identity);
        return res;
    }

    // Start is called before the first frame update
    void Start()
    {        
        enemyPrefab.GetComponent<Enemy>().player = GameObject.Find("Player");

        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemy = SpawnEnemy();
            spawnedEnemies.Add(enemy);            
        }
    }

    private void Awake() {
        spawnedEnemies = new List<GameObject>();
        spawnPoints = new List<Vector3>();
        spawnPoints.Add(new Vector3(-10f,0f,-25f));
        spawnPoints.Add(new Vector3(10f,0f,-25f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
