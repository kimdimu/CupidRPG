using UnityEngine;

public class HealingItem : MonoBehaviour, IInteractable
{
    [SerializeField] int healAmount;
    Health health;
    public void CanInteract()
    {
        //상호작용 UI 띄우기
        InputManager.Instance.OnPressFDown += Interact;
        print("CanInteract");
    }

    public void EndInteract()
    {
        InputManager.Instance.OnPressFDown -= Interact;
        print("EndInteract");
    }

    public void Interact()
    {
        //상호작용 UI 접기
        health.GetDamage(-healAmount);
        EndInteract();
        print("Interact");
    }

    public Transform ReturnTF()
    {
        return transform;
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
