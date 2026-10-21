using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class WeaponWheelController : MonoBehaviour
{
    [Header("Input Settings")]
    public InputAction toggleWheelAction;

    [Header("UI & Animation")]
    public Animator anim;
    public Image selectedItem;
    public Sprite noImage;

    public static int weaponID;
    private bool weaponWheelSelected = false;

    private void OnEnable()
    {
        toggleWheelAction.Enable();
        toggleWheelAction.started += OnToggleWeaponWheel;
    }

    private void OnDisable()
    {
        toggleWheelAction.started -= OnToggleWeaponWheel;
        toggleWheelAction.Disable();
    }

    private void OnToggleWeaponWheel(InputAction.CallbackContext context)
    {
        weaponWheelSelected = !weaponWheelSelected;
        anim.SetBool("OpenWeaponWheel", weaponWheelSelected);
    }

    void Update()
    {
        switch (weaponID)
        {
            case 0:
                selectedItem.sprite = noImage;
                break;
            case 1: //pistol
                Debug.Log("Pistuh");
                break;
            case 2:
                Debug.Log("Melee");
                break;
            case 3:
                Debug.Log("ShotGuh");
                break;
            case 4:
                Debug.Log("Heals");
                break;
        }
    }
}
