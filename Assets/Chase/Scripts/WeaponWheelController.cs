using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class WeaponWheelController : MonoBehaviour
{
    [Header("Input Settings")]
    public InputAction toggleWheelAction;

    [Header("UI & Animation")]
    public Animator anim;
    public Image selectedItem;
    public Sprite noImage;

    public static int weaponID;
    public static event Action<int> OnWeaponSwitched;

    private bool weaponWheelSelected = false;
    private float nextToggleTime = 0f;
    private const float TOGGLE_COOLDOWN = 0.15f;

    private void OnEnable()
    {
        toggleWheelAction.Enable();
        toggleWheelAction.performed += OnToggleWeaponWheel;
    }

    private void OnDisable()
    {
        toggleWheelAction.performed -= OnToggleWeaponWheel;
        toggleWheelAction.Disable();
    }

    private void OnToggleWeaponWheel(InputAction.CallbackContext context)
    {
        if (Time.realtimeSinceStartup < nextToggleTime) return;

        weaponWheelSelected = !weaponWheelSelected;
        anim.SetBool("OpenWeaponWheel", weaponWheelSelected);

        if (weaponWheelSelected)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        nextToggleTime = Time.realtimeSinceStartup + TOGGLE_COOLDOWN;
    }

    public void SelectWeapon(int id)
    {
        if (Time.realtimeSinceStartup < nextToggleTime) return;

        weaponID = id;
        Debug.Log("Weapon switched to ID: " + id);

        OnWeaponSwitched?.Invoke(id);

        weaponWheelSelected = false;
        anim.SetBool("OpenWeaponWheel", false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        nextToggleTime = Time.realtimeSinceStartup + TOGGLE_COOLDOWN;
    }

    void Update()
    {
        switch (weaponID)
        {
            case 0: selectedItem.sprite = noImage; break;
            case 1: break; // pistol
            case 2: break; // Melee
            case 3: break; // ShotGun
            case 4: break; // Heals
        }
    }
}
