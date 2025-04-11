using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    public string promtMessage;
    public void BaseInteract()
    {
        Interact();
    }
    public virtual string OnLook()
    {
        return promtMessage;
    }
    protected virtual void Interact()
    {

    }
}
