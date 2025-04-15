using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private MusicPlayer musicPlayerX, musicPlayerY;

    [SerializeField] private Crossfader crossfader;

    private void Start()
    {
        crossfader.MoveCrossfader += Crossfade;
        //Set Initial volumes of music players
        musicPlayerX.UpdateVolume(1);
        musicPlayerY.UpdateVolume(0);
    }

    private void Crossfade()
    {
        Vector2 newVolumeValues = crossfader.GetMusicPlayerVolumes();

        musicPlayerX.UpdateVolume(newVolumeValues.x);
        musicPlayerY.UpdateVolume(newVolumeValues.y);
    }
    
}
