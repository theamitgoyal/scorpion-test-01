using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private MusicPlayer musicPlayerLeft, musicPlayerRight;

    [SerializeField] private Crossfader crossfader;

    private void Awake()
    {
        crossfader.MoveCrossfader += Crossfade;
        crossfader.InitializeCrossfader();
    }

    private void Crossfade(float newVolumeLeftValue)
    {
        //Left side volume returned by crossfader
        musicPlayerLeft.UpdateVolume(newVolumeLeftValue);
        //Right side volume = 1 - Left side volume
        musicPlayerRight.UpdateVolume(1 - newVolumeLeftValue);
    }
    
}
