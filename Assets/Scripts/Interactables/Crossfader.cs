using System;
using UnityEngine;

public class Crossfader : Interactable
{

    [SerializeField] private float slideSpeed;
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] private Transform centrePos;
    [SerializeField] private GameObject crossFaderKnob;

    public event Action<float> MoveCrossfader;

    protected override void HoldInteract(Vector2 input)
    {
        //Move crossfader knob based on received input
        float movementX = input.x * slideSpeed * Time.deltaTime;
        float crossfaderNewPosX = Mathf.Clamp(crossFaderKnob.transform.position.x + movementX, leftPos.transform.position.x, rightPos.transform.position.x);
        crossFaderKnob.transform.position = new Vector3(crossfaderNewPosX, crossFaderKnob.transform.position.y, crossFaderKnob.transform.position.z);
        //TODO:
        //Instead of analog crossfader movement, move crossfader a fixed step each time A or D is pressed
        //This may need a change to the input setup where A/D and L-Stick are changed from value type to button type

        MoveCrossfader.Invoke(GetMusicPlayerLeftVolume());
    }

    public void InitializeCrossfader()
    {
        //Set Crossfader to left side music player
        crossFaderKnob.transform.position = leftPos.position;
        MoveCrossfader.Invoke(GetMusicPlayerLeftVolume());
    }

    public float GetMusicPlayerLeftVolume()
    {
        float totalDistance = rightPos.position.x - leftPos.position.x;

        float distanceMPlayerX = rightPos.position.x - crossFaderKnob.transform.position.x;
        float distanceMPlayerXNormalized = distanceMPlayerX / totalDistance;

        return distanceMPlayerXNormalized;
    }
}
