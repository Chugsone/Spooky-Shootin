using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 1;
    public GameObject itemDrop;

    private float dropAmount = 0f;
    public float minDrop = 1f;
    public float maxDrop = 5f;

    [SerializeField] private AudioClip deathSound;

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
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
