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

    public void BaseHoldInteract(Vector2 input)
    {
        HoldInteract(input);
    }
    
    protected virtual void Interact()
    {

    }

    protected virtual void HoldInteract(Vector2 input)
    {

    }
}
