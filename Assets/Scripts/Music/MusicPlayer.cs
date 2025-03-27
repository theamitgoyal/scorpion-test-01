using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        Debug.Log("Interacted With Play Button");
    }

    public void Stop()
    {

    }

    public void UpdateVolume(float targetVolume)
    {

    }
}
