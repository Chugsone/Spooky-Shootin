using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyOne;
    public GameObject enemyTwo;
    //public GameObject bossEnemy;

    //public int numberOfBosses = 0;
    public int numberOfEnemies = 2;
    public int currentNumberOfEnemies = 2;
    public int currentWave = 1;
    public int enemyPerWaveIncrease = 2;
    public int endBeforeWave = 26;

    public string sceneName;

    private float randomChance = 0f;

    public float minX = -5f;
    public float maxX = 5f;

    public float minY = -5f;
    public float maxY = 5f;

    [SerializeField] private AudioClip newWaveSound;
    [SerializeField] private AudioClip endOfWaveSound;

    void Update()
        {
            if(currentNumberOfEnemies == 0)
            {
                Debug.Log("Wave Over");
            AudioSource.PlayClipAtPoint(endOfWaveSound, transform.position, 1f);
            //when Marya is finished with the upgrades, replace the calling the SpawnWave function with the shop menu
            SpawnWave();
            }

        }

    public void SpawnWave()
    {
        float xPos, yPos;
        Vector2 pos;

        AudioSource.PlayClipAtPoint(newWaveSound, transform.position, 1f);
        if(currentWave == endBeforeWave)
        {
            SceneManager.LoadScene(sceneName);
        }
        //else if(currentWave % 5 == 0)
        //{
        //    numberOfBosses++;
        //    for (int i = 0; i < numberOfBosses; i++)
        //    {
        //        Instantiate(bossEnemy, gameObject.transform.position, Quaternion.identity);
        //    }
        //}
        else
        {
        for (int i =0; i < numberOfEnemies; i++)
        {
            randomChance = Random.Range(1, 4);

            xPos = Random.Range(minX, maxX);
            yPos = Random.Range(minY, maxY);
            pos = new Vector2(xPos, yPos);

            if (randomChance == 1)
            {
            Instantiate(enemyTwo, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyOne, pos, Quaternion.identity);
            }
                currentNumberOfEnemies++;
        }

        }


        numberOfEnemies = numberOfEnemies + enemyPerWaveIncrease;
        currentWave++;

    }
}
