using UnityEngine;
using UnityEngine.InputSystem;

public class Shotgun : MonoBehaviour
{
    [Header("Weapon Wheel")]
    public int myWeaponID = 3;

    [Header("Visuals")]
    [Tooltip("The visual sprite child of the shotgun")]
    public GameObject weaponModel;

    [Header("Shotgun Attributes")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.8f;

    [Header("Pellet Settings")]
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
        if (WeaponWheelController.weaponID != myWeaponID) return;
        if (Time.timeScale == 0f) return;

        if (IsFireButtonPressed())
        {
            if (Time.realtimeSinceStartup > nextFireTime)
            {
                Shoot();
                nextFireTime = Time.realtimeSinceStartup + fireRate;
            }
        }
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
