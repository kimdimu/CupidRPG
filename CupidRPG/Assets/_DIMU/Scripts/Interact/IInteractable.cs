using UnityEngine;

public interface IInteractable
{
    void Interact();
    void CanInteract(GameObject player);
    void EndInteract();
    Transform ReturnTF();
}
//public interface IDialogueable : IInteractable
//{
//    public void DialogueInteract();
//}

//public interface IEatable : IInteractable
//{
//    public void EatInteract();
//}

public abstract class InteractableObject : MonoBehaviour
{
    public abstract void Interact();
    public abstract void CanInteract();
    public abstract void EndInteract();
}