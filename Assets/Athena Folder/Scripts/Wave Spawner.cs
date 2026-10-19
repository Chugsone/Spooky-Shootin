using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public int numberOfEnemies = 3;
    public int currentWave = 1;
    public GameObject bossEnemy;
    public int numberOfBosses = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnWave()
    {
        for (int i =0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }
        if(currentWave % 5 == 0)
        {
            numberOfBosses++;
            for (int i = 0; i < numberOfBosses; i++)
            {
                Instantiate(bossEnemy, gameObject.transform.position, Quaternion.identity);
            }
        }
        numberOfEnemies = numberOfEnemies + 2;
        currentWave++;
    }
}
