using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip currentMusicTrack;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //preload audio clip to avoid loading during Play() method
        currentMusicTrack.LoadAudioData();
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
