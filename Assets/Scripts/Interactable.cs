using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private string promptMessage;
    [SerializeField] private bool holdToInteract = false;

    public string PromptMessage { get => promptMessage; }
    public bool HoldToInteract { get =>  holdToInteract; }

    public void BaseInteract()
    {
        Interact();
    }
    
    protected virtual void Interact()
    {

    }
}
