using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [Header("Combat Settings")]
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float meleeRange = 1.5f;
    [SerializeField] private int meleeDamage = 10;
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private LayerMask enemyLayer;

    private bool isAttacking = false;
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started && !isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }


    private System.Collections.IEnumerator PerformAttack()
    {
        isAttacking = true;

        // playerAnim.Play("MeleeWhack");

        Collider2D hitEnemy = Physics2D.OverlapCircle(weaponTransform.position, meleeRange, enemyLayer);
        if (hitEnemy != null)
        {
            if (hitEnemy.TryGetComponent<EnemyHealth>(out var enemyHealth))
            {
                enemyHealth.TakeDamage(meleeDamage);
            }
        }

        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (weaponTransform != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(weaponTransform.position, meleeRange);
        }
    }

    public void MeleeDirection(Vector2 moveInput)
    {
        float direction = Mathf.Sign(moveInput.x);

        float localOffset = Mathf.Abs(weaponTransform.localPosition.x);
        weaponTransform.localPosition = new Vector3(localOffset * direction, weaponTransform.localPosition.y, weaponTransform.localPosition.z);

    }
}
