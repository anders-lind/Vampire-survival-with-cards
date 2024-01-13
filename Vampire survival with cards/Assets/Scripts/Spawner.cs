using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject player;

    float startTime;
    float timeSinceLastSpawnedEnemy = 0;

    [SerializeField] List<GameObject> enemyTypes = new();

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawnedEnemy += Time.deltaTime;

        if (timeSinceLastSpawnedEnemy > 1){
            spawnEnemy(enemyTypes[Random.Range(0, enemyTypes.Count)]);
        }
    }

    void spawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab);
        Vector3 offset = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f));
        if (offset == Vector3.zero)
            offset = new Vector3(1,1);
            
        offset = offset.normalized * 5;
        enemy.transform.position = player.transform.position + offset;
        
        timeSinceLastSpawnedEnemy = 0;
    }
}
