using UnityEngine;

public class WeaponPickUp : MonoBehaviour, IInteractable
{
    [SerializeField]
    Weapon weaponData;
    Fighter fighter;
    private void Awake()
    {
        weaponData.InstantiateFab(transform);
    }
    public void CanInteract(GameObject player)
    {
        fighter = player.GetComponent<Fighter>();
        InputManager.Instance.OnPressFDown = Interact;
    }

    public void EndInteract()
    {
    }

    public void Interact()
    {
        if (!fighter) return;
        fighter.AddWeapon(weaponData);
    }

    public Transform ReturnTF()
    {
        return transform;
    }
}
