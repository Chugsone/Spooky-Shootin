using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 1;
    public GameObject itemDrop;

    private float dropAmount = 0f;
    public float minDrop = 1f;
    public float maxDrop = 5f;
    public bool canTakeDamage = true;

    public WaveSpawner ws;

    [SerializeField] private AudioClip deathSound;
    void Start()
    {
        GameObject spawnManager = GameObject.FindGameObjectWithTag("SpawnManager");
        if (spawnManager != null)
        {
            ws = spawnManager.GetComponent<WaveSpawner>();
        }
    }
    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0 && canTakeDamage == true)
        {
            ws.currentNumberOfEnemies--;
            canTakeDamage = false;
            dropAmount = Random.Range(minDrop, maxDrop);
            for (int i = 0; i < dropAmount; i++)
            {
                Instantiate(itemDrop, transform.position, Quaternion.identity);
            }
            AudioSource.PlayClipAtPoint(deathSound, transform.position, 1f);

            Destroy(gameObject);
        }
    }
}
