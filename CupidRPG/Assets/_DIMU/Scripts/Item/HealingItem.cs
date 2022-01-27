using UnityEngine;

public class HealingItem : InteractableObject
{
    [SerializeField] int healAmount;
    Health health;
    public override void CanInteract()
    {
        //상호작용 UI 띄우기
        InputManager.Instance.OnPressFDown += Interact;
        print("CanInteract");
    }

    public override void EndInteract()
    {
        InputManager.Instance.OnPressFDown -= Interact;
        print("EndInteract");
    }

    public override void Interact()
    {
        //상호작용 UI 접기
        health.GetDamage(-healAmount);
        EndInteract();
        print("Interact");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        Debug.Log("추돌");
        if (health && collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
