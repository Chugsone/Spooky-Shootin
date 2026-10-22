using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    [Header("Weapon Wheel Integration")]
    public int myWeaponID = 1;

    [Header("Visuals")]
    public GameObject weaponModel;

    [Header("Pistol Attributes")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;

    private void Update()
    {
        HandleVisibility();

        if (WeaponWheelController.weaponID != myWeaponID) return;

        if (Time.timeScale == 0f) return;

        // 4. Fire Input Check
        if (IsFireButtonPressed())
        {
            if (Time.realtimeSinceStartup > nextFireTime)
            {
                Shoot();
                nextFireTime = Time.realtimeSinceStartup + fireRate;
            }
        }
    }

    private void HandleVisibility()
    {
        if (WeaponWheelController.weaponID == myWeaponID)
        {
            if (weaponModel != null && !weaponModel.activeSelf)
            {
                weaponModel.SetActive(true);
                Debug.Log("Pistol Mesh Activated successfully!");
            }
        }
        else
        {
            if (weaponModel != null && weaponModel.activeSelf)
            {
                weaponModel.SetActive(false);
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
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
