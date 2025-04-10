using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private MusicPlayer musicPlayerX, musicPlayerY;

    [SerializeField] private Crossfader crossfader;

    private void Awake()
    {
        crossfader.MoveCrossfader += Crossfade;
    }

    private void Crossfade()
    {
        Vector2 newVolumeValues = crossfader.GetMusicPlayerVolumes();

        musicPlayerX.UpdateVolume(newVolumeValues.x);
        musicPlayerY.UpdateVolume(newVolumeValues.y);
    }
    
}
