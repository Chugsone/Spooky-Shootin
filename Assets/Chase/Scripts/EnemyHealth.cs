using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 1;

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
