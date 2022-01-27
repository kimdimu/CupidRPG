using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] List<InteractableObject> interacts = new List<InteractableObject>();
    InteractableObject closestObj;

    public void OnTriggerEnter(Collider other)
    {
        InteractableObject interactable = other.GetComponent<InteractableObject>();
        if (interactable != null)
        {
            interacts.Add(interactable);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        InteractableObject interactable = other.GetComponent<InteractableObject>();
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
        DistChect();
        closestObj.CanInteract();
    }
    public void DistChect()
    {
        float shortestDist = 1000000;

        foreach (var item in interacts)
        {
            float dist = Vector3.Distance(transform.position, item.transform.position);
            if (dist < shortestDist)
            {
                shortestDist = dist;
                closestObj = item;
            }
        }

    }
}
