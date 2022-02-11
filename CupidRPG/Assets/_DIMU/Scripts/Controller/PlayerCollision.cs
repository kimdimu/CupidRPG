using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] List<IInteractable> interacts = new List<IInteractable>();
    IInteractable closestObj;

    public void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interacts.Add(interactable);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interacts.Remove(interactable);
        }
    }
    public void Update()
    {
        LightClosestObj();
    }
    public void LightClosestObj()
    {
        if (interacts.Count < 0) return;
        DistChect();
        closestObj.CanInteract();
    }
    public void DistChect()
    {
        float shortestDist = 1000000;

        foreach (var item in interacts)
        {
            float dist = Vector3.Distance(transform.position, item.ReturnTF().position);
            if (dist < shortestDist)
            {
                shortestDist = dist;
                closestObj = item;
            }
        }

    }
}
