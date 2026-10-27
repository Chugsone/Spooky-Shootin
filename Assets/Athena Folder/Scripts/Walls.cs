using UnityEngine;

public class Walls : MonoBehaviour
{
    // The Melee Enemy has a habit of going out of bounds, so the walls kill it now
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
        }
    }
}
