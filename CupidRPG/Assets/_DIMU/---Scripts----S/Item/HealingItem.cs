using UnityEngine;

public class HealingItem : MonoBehaviour, IInteractable
{
    [SerializeField] int healAmount;
    Health health;

    public void CanInteract(GameObject player)
    {
        if (!health)
            health = player.GetComponent<Health>();
        InputManager.Instance.OnPressFDown = Interact;
        print("CanInteract " + gameObject.name);
    }

    public void EndInteract()
    {
        //InputManager.Instance.OnPressFDown -= Interact;
        print("EndInteract");
    }

    public void Interact()
    {
        //상호작용 UI 접기
        health.GetDamage(-healAmount);
        print("Interact");
        EndInteract();
    }

    public Transform ReturnTF()
    {
        return transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("추돌");
        if (health && collision.collider.CompareTag("Player"))
        {
            //Destroy(gameObject);
        }
    }
}
