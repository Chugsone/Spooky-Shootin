using UnityEngine;
using UnityEngine.InputSystem;

public class Shotgun : MonoBehaviour
{
    [Header("Weapon Wheel")]
    public int myWeaponID = 3;

    public GameObject weaponModel;

    [Header("Shotgun Attributes")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.8f;

    public int pelletCount = 5;
    public float spreadAngle = 15f;

    private float nextFireTime = 0f;

    private void OnEnable()
    {
        WeaponWheelController.OnWeaponSwitched += CheckWeaponActivation;
    }

    private void OnDisable()
    {
        WeaponWheelController.OnWeaponSwitched -= CheckWeaponActivation;
    }

    private void Start()
    {
        CheckWeaponActivation(WeaponWheelController.weaponID);
    }

    private void CheckWeaponActivation(int activeWeaponID)
    {
        bool shouldBeVisible = (activeWeaponID == myWeaponID);
        if (weaponModel != null)
        {
            weaponModel.SetActive(shouldBeVisible);
        }
    }

    private void Update()
    {
        bool isActiveWeapon = (WeaponWheelController.weaponID == myWeaponID);

        if (weaponModel != null && weaponModel.activeSelf != isActiveWeapon)
        {
            weaponModel.SetActive(isActiveWeapon);
        }

        if (!isActiveWeapon) return;
        if (Time.timeScale == 0f) return;

        AimAtMouse();

        if (IsFireButtonPressed())
        {
            if (Time.realtimeSinceStartup > nextFireTime)
            {
                Shoot();
                nextFireTime = Time.realtimeSinceStartup + fireRate;
            }
        }
    }

    private void AimAtMouse()
    {
        if (Mouse.current == null) return;

        Vector2 mousePixelPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePixelPos.x, mousePixelPos.y, transform.position.z));
        mouseWorldPos.z = transform.position.z;

        Vector2 lookDirection = ((Vector2)mouseWorldPos - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        float parentXScale = transform.parent != null ? transform.parent.lossyScale.x : 1f;

        if (parentXScale < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }

        if (weaponModel != null)
        {
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
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private bool IsFireButtonPressed()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed) return true;
        if (Gamepad.current != null && Gamepad.current.rightTrigger.isPressed) return true;
        return false;
    }

    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        Debug.Log("Shotgun Fired!");

        float startAngle = -spreadAngle / 2f;
        float angleStep = pelletCount > 1 ? spreadAngle / (pelletCount - 1) : 0f;

        for (int i = 0; i < pelletCount; i++)
        {
            float currentPelletAngle = startAngle + (angleStep * i);

            Quaternion pelletRotation = firePoint.rotation * Quaternion.Euler(0, 0, currentPelletAngle);

            Instantiate(bulletPrefab, firePoint.position, pelletRotation);
        }
    }
    
}
