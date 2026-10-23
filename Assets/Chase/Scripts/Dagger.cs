using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dagger : MonoBehaviour
{
    [Header("Weapon Wheel")]
    public int myWeaponID = 2; 
    public GameObject weaponModel; 

    [Header("Melee Attributes")]
    public int damageAmount = 20;
    public float attackRange = 1.5f;
    public float attackCooldown = 0.5f;
    public Transform attackPoint; 
    public LayerMask enemyLayers;

    [Header("Lunge Settings")]
    public float lungeForce = 12f;
    public float lungeDuration = 0.12f;

    [HideInInspector] public bool isLunging = false; 
    
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float nextAttackTime = 0f;
    private bool isActiveWeapon = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        CheckWeaponActivation(WeaponWheelController.weaponID);
    }

    private void OnEnable()
    {
        WeaponWheelController.OnWeaponSwitched += CheckWeaponActivation;
    }

    private void OnDisable()
    {
        WeaponWheelController.OnWeaponSwitched -= CheckWeaponActivation;
    }

    private void CheckWeaponActivation(int activeWeaponID)
    {
        isActiveWeapon = (activeWeaponID == myWeaponID);
        if (weaponModel != null)
        {
            weaponModel.SetActive(isActiveWeapon);
        }
    }

    public void MeleeDirection(Vector2 moveInput)
    {
    }

    private void Update()
    {
        if (weaponModel != null && weaponModel.activeSelf != isActiveWeapon)
        {
            weaponModel.SetActive(isActiveWeapon);
        }

        if (!isActiveWeapon || Time.timeScale == 0f) return;

        if (!isLunging)
        {
            AimAtMouse();
        }

        if (IsFireButtonPressed())
        {
            if (Time.realtimeSinceStartup > nextAttackTime && !isLunging)
            {
                StartCoroutine(PerformAttackWithLunge());
                nextAttackTime = Time.realtimeSinceStartup + attackCooldown;
            }
        }
    }

    private void AimAtMouse()
    {
        if (Mouse.current == null || weaponModel == null) return;

        Vector2 mousePixelPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(new Vector3(mousePixelPos.x, mousePixelPos.y, transform.position.z));
        mouseWorldPos.z = transform.position.z;

        Vector2 lookDirection = ((Vector2)mouseWorldPos - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        weaponModel.transform.parent.rotation = Quaternion.Euler(0f, 0f, angle);

        Vector3 modelScale = weaponModel.transform.localScale;
        if (mouseWorldPos.x < transform.position.x)
        {
            weaponModel.transform.localScale = new Vector3(modelScale.x, -Mathf.Abs(modelScale.y), modelScale.z);
        }
        else
        {
            weaponModel.transform.localScale = new Vector3(modelScale.x, Mathf.Abs(modelScale.y), modelScale.z);
        }
    }

    private bool IsFireButtonPressed()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed) return true;
        if (Gamepad.current != null && Gamepad.current.rightTrigger.isPressed) return true;
        return false;
    }

    IEnumerator PerformAttackWithLunge()
    {
        isLunging = true;

        Vector2 lungeDirection = weaponModel.transform.parent.right;

        float timer = 0f;
        while (timer < lungeDuration)
        {
            rb.linearVelocity = lungeDirection * lungeForce;
            timer += Time.deltaTime;
            yield return null;
        }

        rb.linearVelocity = Vector2.zero;
        isLunging = false;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            var enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
