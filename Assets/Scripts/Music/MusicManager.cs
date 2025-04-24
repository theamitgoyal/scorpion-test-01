using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private MusicPlayer musicPlayerX, musicPlayerY;

    [SerializeField] private Crossfader crossfader;

    private void Awake()
    {
        crossfader.MoveCrossfader += Crossfade;
        crossfader.InitializeCrossfader();
    }

    private void Crossfade(Vector2 newVolumeValues)
    {
        musicPlayerX.UpdateVolume(newVolumeValues.x);
        Debug.Log(musicPlayerX.GetVolume());
        musicPlayerY.UpdateVolume(newVolumeValues.y);
        Debug.Log(musicPlayerY.GetVolume());
    }
    
}
