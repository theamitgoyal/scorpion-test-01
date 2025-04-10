using UnityEngine;

public class PlayButton : Interactable
{
    Animator animator;
    MusicPlayer musicPlayer;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        musicPlayer = GetComponentInParent<MusicPlayer>();
    }

    void Update()
    {
        
    }

    protected override void Interact()
    {
        animator.SetTrigger("PlayerInteract");
        musicPlayer.Play();
    }
}
