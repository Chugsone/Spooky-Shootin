using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject bossEnemy;

    public int numberOfBosses = 0;
    public int numberOfEnemies = 3;
    public int currentWave = 1;
    public int enemyPerWaveIncrease = 2;

    public float radNum = 0f;

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
            radNum = Random.Range(1, 4);
            Debug.Log(radNum);
            if(radNum == 1)
            {
            Instantiate(enemyTwo, gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyOne, gameObject.transform.position, Quaternion.identity);
            }
        }
        if(currentWave % 5 == 0)
        {
            numberOfBosses++;
            for (int i = 0; i < numberOfBosses; i++)
            {
                Instantiate(bossEnemy, gameObject.transform.position, Quaternion.identity);
            }
        }
        numberOfEnemies = numberOfEnemies + enemyPerWaveIncrease;
        currentWave++;
    }
}
