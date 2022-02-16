using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] List<IInteractable> interacts = new List<IInteractable>();
    IInteractable closestObj;
    public GameObject collisionUI;

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
        if (interacts.Count == 0)
        {
            collisionUI.SetActive(false);
            return;
        }
        collisionUI.SetActive(true);

        DistChect();
        closestObj.CanInteract(gameObject.transform.parent.gameObject);

        Vector3 uiPos = new Vector3(closestObj.ReturnTF().position.x, closestObj.ReturnTF().position.y + 4, closestObj.ReturnTF().position.z);
        collisionUI.transform.position = Camera.main.WorldToScreenPoint(uiPos);
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
