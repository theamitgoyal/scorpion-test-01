using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Crossfader : Interactable
{

    [SerializeField] private float slideSpeed;
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] private Transform centrePos;
    [SerializeField] private GameObject crossFaderKnob;

    public event Action MoveCrossfader;

    private void Start()
    {
        crossFaderKnob.transform.position = leftPos.position;
        MoveCrossfader.Invoke();
    }

    protected override void HoldInteract(Vector2 input)
    {
        //Move crossfader knob based on received input
        float movementX = input.x * slideSpeed * Time.deltaTime;
        float crossfaderNewPosX = Mathf.Clamp(crossFaderKnob.transform.position.x + movementX, leftPos.transform.position.x, rightPos.transform.position.x);
        crossFaderKnob.transform.position = new Vector3(crossfaderNewPosX, crossFaderKnob.transform.position.y, crossFaderKnob.transform.position.z);

        MoveCrossfader.Invoke();
    }
    
    public Vector2 GetMusicPlayerVolumes()
    {
        float totalDistance = rightPos.position.x - leftPos.position.x;

        float distanceMPlayerX = rightPos.position.x - crossFaderKnob.transform.position.x;
        float distanceMPlayerXNormalized = distanceMPlayerX / totalDistance;

        float distanceMPlayerY = crossFaderKnob.transform.position.x - leftPos.position.x;
        float distanceMPlayerYNormalized = distanceMPlayerY / totalDistance;

        return new Vector2(distanceMPlayerXNormalized, distanceMPlayerYNormalized);
    }
}
