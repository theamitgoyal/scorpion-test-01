using UnityEngine;

public class PlayButton : Interactable
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    protected override void Interact()
    {
        Debug.Log("Interacted With Play Button");
        //Play music and animate button on interact
        animator.SetTrigger("PlayerInteract");
        base.Interact();
    }
}
