using UnityEngine;

public class PlayButton : Interactable
{
    private Animator animator;
    private MusicPlayer musicPlayer;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        musicPlayer = GetComponentInParent<MusicPlayer>();
    }

    protected override void Interact()
    {
        animator.SetTrigger("PlayerInteract");
        musicPlayer.Play();

        //TODO:
        //If Music is playing, pressing button again should pause the track
        //Change button material to emissive when track is playing
        //Make button material switch between emissive and regule when track is paused
    }
}
