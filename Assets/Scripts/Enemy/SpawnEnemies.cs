using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public int round = 1;
    [SerializeField]
    int zombiesInRound = 10;
    [SerializeField]
    int zombiesSpawnedInRound = 0;

    float zombieSpawnTimer = 0;

    public Transform[] zombieSpawnPoints;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(zombiesSpawnedInRound < zombiesInRound)
        {
            if(zombieSpawnTimer > 3)
            {
                SpawnZombie();
                zombieSpawnTimer = 0;
            }
            else
            {
                zombieSpawnTimer += Time.deltaTime;
            }
        }
    }
    void SpawnZombie()
    {
        Vector3 randomSpawnPoint = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)].position;
        Instantiate(Enemy, randomSpawnPoint, Quaternion.identity);
        zombiesSpawnedInRound++;
    }
}
