using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip currentMusicTrack;
    [Range(0f, 1f)] [SerializeField] private float volume = 0.5f;
    
    AudioSource audioSource;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
    
    public void Play()
    {
        if (!audioSource) return;

        if (!currentMusicTrack)
        {
            Debug.LogWarning("No Music Assigned");
            return;
        }
        
        audioSource.clip = currentMusicTrack;
        audioSource.volume = volume;
        audioSource.Play();

    }

    public void Stop()
    {
        if (!audioSource) return;
        if (!IsPlaying()) return;

        audioSource.Stop();
    }

    public void Pause()
    {
        if (!audioSource) return;
        if (!IsPlaying()) return;


        audioSource.Pause();
    }
    public void UpdateVolume(float targetVolume)
    {
        if (!audioSource) return;

        audioSource.volume = targetVolume;
    }
}
